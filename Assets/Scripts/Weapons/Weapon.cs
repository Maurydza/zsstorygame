using UnityEngine;

public abstract class Weapon : Item
{
    public int ammo = 10;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 15f;

    public override void Use()
    {
        Shoot();
    }

    void Shoot()
    {
        if (ammo <= 0)
        {
            Debug.Log("Brak amunicji");
            return;
        }

        ammo--;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        Vector2 direction = (mousePos - firePoint.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        Bullet b = bullet.GetComponent<Bullet>();
        b.SetDirection(direction);
        b.speed = bulletSpeed;
        b.damage = damage;

        Sound();
    }

    public float damage = 10f;
    public abstract void Sound();
}