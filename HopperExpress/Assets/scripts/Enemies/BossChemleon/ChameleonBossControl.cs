using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChameleonBossControl : MonoBehaviour
{
    private MonsterManager monsterManager;
    public GameObject ShockWave;
    public Transform SpawnPoint;
    public GameObject minion1;
    public GameObject minion2;
    public GameObject minion3;
    private bool Spawned1 = false;
    private bool Spawned2 = false;
    private bool Spawned3 = false;
    private bool StartAttack = false;
    private float attackInterval = 1.5f;  
    void Start()
    {
        Wavespawner.monsCount += 1;
        monsterManager = GetComponent<MonsterManager>();
    }

    void Update()
    {
        //Debug.Log("HP" + monsterManager.m_HP);
        if (monsterManager.m_HP <= 75)
        {
            Spawn1();
        }
        else if (monsterManager.m_HP <= 150)
        {
            Spawn2();
        }
        else if (monsterManager.m_HP <= 250)
        {
            Spawn3();
        }
        if (StartAttack)
        {
            if (!IsInvoking("Attack"))
            {
                InvokeRepeating("Attack", 0f, attackInterval);  
            }
        }
    }

    public void Attack()
    {
        Instantiate(ShockWave, SpawnPoint.position, Quaternion.identity);
    }
    void Spawn1()
    {
        if (!Spawned1)
        {

            Spawned1 = true;
            Instantiate(minion1, new Vector3(transform.position.x - 3f, transform.position.y, transform.position.z), transform.rotation);
        }
    }
    void Spawn2()
    {
        if (!Spawned2)
        {

            Spawned2 = true;
            Instantiate(minion2, new Vector3(transform.position.x - 3f, transform.position.y, transform.position.z), transform.rotation);
        }
    }
    void Spawn3()
    {
        if (!Spawned3)
        {

            Spawned3 = true;
            Instantiate(minion3, new Vector3(transform.position.x - 3f, transform.position.y, transform.position.z), transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BossRange"))
        {
            StartAttack = true;
            monsterManager.moveSpeed = 0;
        }


    }
    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("BossRange"))
        {
            monsterManager.moveSpeed = 2;

        }
    }
}
