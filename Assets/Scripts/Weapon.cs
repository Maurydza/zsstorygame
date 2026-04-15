using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Weapon : Item
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float fireRate = 5f;
    public float damage = 10f;
    public float bulletSpeed = 20f;

    float nextTimeToFire = 0f;

    void Update()
    {
        string sceneName = SceneManager.GetActiveScene().name.ToLower();

        if (!(sceneName.StartsWith("s49") ||
              sceneName.StartsWith("s59") ||
              sceneName.StartsWith("s69") ||
              sceneName.StartsWith("sp1") ||
              sceneName.StartsWith("sp2")))
            return;

        if (Mouse.current.leftButton.isPressed && Time.time >= nextTimeToFire)
        {
            Shoot();
            nextTimeToFire = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        Debug.Log("shooting...");
        if (bulletPrefab == null || firePoint == null)
        {
            Debug.LogError("Brak bulletPrefab lub firePoint!");
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        bullet.transform.localScale = new Vector3(7f, 7f, 1f); 
        bullet.transform.parent = null;

        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            Collider2D playerCol = player.GetComponent<Collider2D>();
            Collider2D bulletCol = bullet.GetComponent<Collider2D>();

            if (playerCol != null && bulletCol != null)
            {
                Physics2D.IgnoreCollision(bulletCol, playerCol);
            }
        }

        Vector3 mousePos = Mouse.current.position.ReadValue();
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.z = 0f;

        Vector2 direction = (worldPos - firePoint.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0, 0, angle);

        Bullet b = bullet.GetComponent<Bullet>();
        if (b != null)
            b.damage = damage;

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.linearVelocity = direction * bulletSpeed;
    }
}