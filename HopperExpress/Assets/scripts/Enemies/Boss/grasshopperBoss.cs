using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grasshopperBoss : MonoBehaviour
{
    // Start is called before the first frame update
    private MonsterManager monsterManager;
    public GameObject minions;
    public float moveSpeed = 2f;
    public GameObject target;
    public float spawnRate = 2f;
    public float setSpawnRate = 2f;

    void Start()
    {
        monsterManager = GetComponent<MonsterManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToTarget();
        Debug.Log("HP:" + monsterManager.m_HP);

        if (monsterManager.m_HP<=151) 
        {
            SpawnMinions();
        }
        if (monsterManager.m_HP<=100)
        {
            SpawnMinions();

        }
    }



    void SpawnMinions()
    {
        spawnRate -=Time.deltaTime;
        if (spawnRate <= 0)
        {
            Instantiate(minions, transform.position, Quaternion.identity);
            spawnRate = setSpawnRate;
        }


    }
    void MoveToTarget()
    {
        if (target != null)
        {
            Vector3 currentPosition = transform.position;

            Vector3 targetPosition = new Vector3(target.transform.position.x, 0f + 3, 0f);

            transform.position = Vector3.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("MonsterAttackRange"))
        {
            moveSpeed = 0;
        }

    }
    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("MonsterAttackRange"))
        {
            moveSpeed = 1.5f;
        }
    }
}