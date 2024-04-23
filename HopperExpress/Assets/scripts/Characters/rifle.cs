using System.Collections;
using UnityEngine;

public class rifle : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public int ammo = 20;
    public int bulletLeft = 20;
    public float reloadTime = 3;
    public bool isShooting = false;
    private bool firstShot = false;
    public float cooldown = 0.1f;
    float shootTimer = 0;
    float shootTimer2 = 0;


    private void Start()
    {
        isShooting = false;
        firstShot = false;
        shootTimer = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && firstShot == false && bulletLeft > 0)
        {
            Shoot(bulletPrefab, bulletSpawnPoint);
            firstShot = true;
            shootTimer2 += Time.deltaTime;
        }

        if (shootTimer2 >= cooldown)
        {
            firstShot = false;
        }

        if (Input.GetMouseButton(0) && bulletLeft > 0)
        {
            isShooting = true;
        }
        else
        {
            isShooting = false;
        }

        if (bulletLeft <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                StartCoroutine(Reload());
            }
        }

        if (isShooting)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer >= cooldown)
            {
                Shoot(bulletPrefab, bulletSpawnPoint);
                shootTimer = 0f;
            }
        }
    }

    public void Shoot(GameObject bulletPrefab, Transform bulletSpawnPoint)
    {
        if (bulletPrefab != null && bulletSpawnPoint != null)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = bulletSpawnPoint.position.z - Camera.main.transform.position.z;

            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Vector3 shootDirection = (worldMousePosition - bulletSpawnPoint.position).normalized;

            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

            bullet.GetComponent<Rigidbody>().velocity = shootDirection * 40f;
        }

        bulletLeft--;
    }

    IEnumerator Reload()
    {
        WeaponSwap.reloading = true;
        isShooting = false; 
        shootTimer = 0f;   
        yield return new WaitForSeconds(reloadTime);
        bulletLeft = ammo;
        isShooting = true;
        WeaponSwap.reloading = false;

    }


}
