using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowIce : MonoBehaviour
{
    public Transform SpawnPoint;
    public GameObject projectile;
    public float speedx = 3;
    public float speedy = 3;
    bool readyToThrow;
    public float iceBombCD = 15;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        timer = iceBombCD;
        readyToThrow = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(timer);
        if (Input.GetKeyDown(KeyCode.Q) && Skills.skill_throwice == true && readyToThrow == true)
        {
            readyToThrow = false;
            if (CharacterMove.moveRight == true)
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
        if (readyToThrow == false)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                readyToThrow = true;
                timer = iceBombCD;

            }
        }
    }
}
