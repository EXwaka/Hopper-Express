using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileControl : MonoBehaviour
{
    private Transform target;
    public float speed = 5f;
    public float rotationSpeed = 200f; 
    private bool isLaunching = true; 
    public GameObject explosionArea; 
    private bool canTriggerCollision = false; 

    private List<MonsterManager> monsterList = new List<MonsterManager>(); 

    void Start()
    {
        UpdateEnemyList();
        SetClosestTarget();

        StartCoroutine(MissileLifecycle());
    }

    void Update()
    {
        if (isLaunching)
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

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            transform.position += transform.right * speed * Time.deltaTime;
        }
        else
        {
            SetClosestTarget();
        }
    }

    void UpdateEnemyList()
    {
        monsterList.Clear();
        MonsterManager[] monsters = FindObjectsOfType<MonsterManager>();
        monsterList.AddRange(monsters);
    }

    void SetClosestTarget()
    {
        float closestDistance = Mathf.Infinity;
        Transform closestEnemy = null;

        foreach (MonsterManager monster in monsterList)
        {
            if (monster == null) continue; 

            float distance = Vector3.Distance(transform.position, monster.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = monster.transform;
            }
        }

        target = closestEnemy;
    }

    IEnumerator MissileLifecycle()
    {
        yield return new WaitForSeconds(1.3f);
        isLaunching = false;
        canTriggerCollision = true;

        yield return new WaitForSeconds(1.7f);
        TriggerExplosion();
    }

    void TriggerExplosion()
    {
        if (explosionArea != null)
        {
            Instantiate(explosionArea, transform.position, transform.rotation);
        }
        Destroy(gameObject); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canTriggerCollision && other.CompareTag("Enemy"))
        {
            TriggerExplosion(); 
        }
    }
}
