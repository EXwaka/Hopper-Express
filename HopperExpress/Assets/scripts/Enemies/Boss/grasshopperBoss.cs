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
    private float spawnRate = 12f;
    private float setSpawnRate = 12f;
    Animator animator;
    //private bool StartSummon;
    public Transform[] spawnPoints;

    void Start()
    {
        //StartSummon = false;
        animator = GetComponent<Animator>();
        Wavespawner.monsCount = 1;
        monsterManager = GetComponent<MonsterManager>();
        Invoke("StartAttack", 5);
    }

    // Update is called once per frame
    void Update()
    {
        MoveToTarget();
        //Debug.Log(Wavespawner.monsCount);

        spawnRate -= Time.deltaTime;
        if (spawnRate <= 0)
        {
            SpawnMinions();
            spawnRate = setSpawnRate;


        }
 
    }

    void SpawnMinions()
    {
        FindObjectOfType<AudioManager>().Play("summon");
        animator.SetTrigger("Summon");


        List<int> selectedIndices = new List<int>();
        while (selectedIndices.Count < 6)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            if (!selectedIndices.Contains(randomIndex))
            {
                selectedIndices.Add(randomIndex);
            }
        }

        foreach (int index in selectedIndices)
        {
            Instantiate(minions, spawnPoints[index].position, Quaternion.identity);
            Wavespawner.monsCount++;
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

    //void StartAttack()
    //{
    //    StartSummon=true;
    //}
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("MonsterAttackRange"))
        {
            moveSpeed = 0;
            monsterManager.moveSpeedMax = 0;
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
