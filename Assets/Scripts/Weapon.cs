using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : Item
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float fireRate = 5f;
    public float damage = 10f;
    public float bulletSpeed = 20f;

    float nextTimeToFire = 0f;

    public override void Start()
    {
        base.Start();
        PutInHand();
    }

    void Update()
    {
        if (!IsEquipped()) return;

        if (Mouse.current.leftButton.isPressed && Time.time >= nextTimeToFire)
        {
            Shoot();
            nextTimeToFire = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || firePoint == null)
        {
            Debug.LogError("Brak bulletPrefab lub firePoint!");
            return;
        }

        Debug.Log("STRZAL");

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // ignoruj kolizję z graczem
        Collider2D playerCol = GetComponent<Collider2D>();
        Collider2D bulletCol = bullet.GetComponent<Collider2D>();
        if (playerCol != null && bulletCol != null)
        {
            Physics2D.IgnoreCollision(bulletCol, playerCol);
        }

        // kierunek do myszki
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.z = 0f;

        Vector2 direction = (worldPos - firePoint.position).normalized;

        // obrót pocisku
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0, 0, angle);

        // damage
        Bullet b = bullet.GetComponent<Bullet>();
        if (b != null)
            b.damage = damage;

        // ruch
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.linearVelocity = direction * bulletSpeed;
    }
}