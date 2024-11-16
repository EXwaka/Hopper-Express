using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileControl : MonoBehaviour
{
    private Transform target;
    public float speed = 5f;
    public float rotationSpeed = 200f;
    private bool Launching=true;
    public GameObject explosionArea;
    private bool canTriggerCollision = false;

    void Start()
    {
        canTriggerCollision = false;

        MonsterManager[] monsters = FindObjectsOfType<MonsterManager>();
        if (monsters.Length > 0)
        {
            target = GetClosestEnemy(monsters);
        }
        Invoke("StopLaunching", 1.3f);
        Invoke("selfDestruction", 3);
    }

    void Update()
    {
        if(Launching)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);

        }
        else
        {
            TrackEnemy();
        }
    }

    void TrackEnemy()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            direction.Normalize();

            // Calculate the angle to rotate towards the target
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Create a new rotation with the current X and Y rotation, but update only the Z rotation
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);

            // Get the current rotation and set its X and Y values to preserve them
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

            // Move the missile towards the target
            transform.position += transform.right * speed * Time.deltaTime;
        }
    }
    Transform GetClosestEnemy(MonsterManager[] monsters)
    {
        Transform closestEnemy = null;
        float closestDistance = Mathf.Infinity;  

        foreach (MonsterManager monster in monsters)
        {
            float distance = Vector3.Distance(transform.position, monster.transform.position);  
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = monster.transform; 
            }
        }

        return closestEnemy;
    }
    void StopLaunching()
    {
        Launching=false;
        canTriggerCollision = true;

    }
    void selfDestruction()
    {
        GameObject ExplosionArea = Instantiate(explosionArea, transform.position, transform.rotation);

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (canTriggerCollision && other.CompareTag("Enemy"))
        {

            selfDestruction();
        }
    }
}
