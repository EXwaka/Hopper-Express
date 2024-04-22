using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGun : MonoBehaviour
{
    // Reference to the bullet prefab and spawn point
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public int ammo=10;
    public int bulletLeft=10;
    public float reloadTime = 3;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&bulletLeft>0)
        {
            Shoot(bulletPrefab, bulletSpawnPoint);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Reload());
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
        yield return new WaitForSeconds(reloadTime);
        bulletLeft = ammo;
    }
}
