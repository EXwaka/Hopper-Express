using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowFire : MonoBehaviour
{
    public Transform SpawnPoint;
    public GameObject projectile;
    public float speedx=3;
    public float speedy=5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)&&Skills.skill_throwfire==true)
        {
            if(CharacterMove.moveRight==true)
            {
                Vector3 spawnPosition = new Vector3(0.8f + SpawnPoint.position.x, 1f + SpawnPoint.position.y, SpawnPoint.position.z);
                var _projectile = Instantiate(projectile, spawnPosition, transform.rotation);
                _projectile.GetComponent<Rigidbody>().velocity = new Vector3(speedx, speedy, 0);
            }
            else
            {
                Vector3 spawnPosition = new Vector3(-0.8f + SpawnPoint.position.x, 1f + SpawnPoint.position.y, SpawnPoint.position.z);
                var _projectile = Instantiate(projectile, spawnPosition, transform.rotation);
                _projectile.GetComponent<Rigidbody>().velocity = new Vector3(-speedx, speedy, 0);
            }

        }
    }
}
