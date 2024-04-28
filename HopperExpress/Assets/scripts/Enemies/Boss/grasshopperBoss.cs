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
    bool wave1 = false;
    void Start()
    {
        monsterManager = GetComponent<MonsterManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToTarget();

        if (monsterManager.m_HP<=151&& wave1 == false) 
        {
            SpawnMinions();
        }
    }
    void SpawnMinions()
    {

        Instantiate(minions, transform.position, Quaternion.identity);
        wave1 = true;

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
