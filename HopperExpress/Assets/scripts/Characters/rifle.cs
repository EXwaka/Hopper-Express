using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rifle : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public bool isShooting=false;
    private bool firstShot = false;
    public float cooldown=0.2f;
    float shootTimer = 0;
    float shootTimer2 = 0;
    // Update is called once per frame
    private void Start()
    {
        isShooting = false;
        firstShot = false;
        shootTimer = 0;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&firstShot==false)
        {
            CharacterMove.Shoot(bulletPrefab, bulletSpawnPoint);
            firstShot = true;
            shootTimer2 += Time.deltaTime;
        }
        if (shootTimer2 >= cooldown)
        {
            firstShot = false;

        }
        if (Input.GetMouseButton(0))
        {
            isShooting = true;
        }
        else
        {
            isShooting = false;
        }

        if (isShooting)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer >= cooldown)
            {
                CharacterMove.Shoot(bulletPrefab, bulletSpawnPoint);
                shootTimer = 0f;
            }
        }
    }
}

