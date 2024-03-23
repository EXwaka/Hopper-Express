using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGun : MonoBehaviour
{
    // Reference to the bullet prefab and spawn point
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CharacterMove.Shoot(bulletPrefab, bulletSpawnPoint);
        }
    }
}
