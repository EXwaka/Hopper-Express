using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterSpawn : MonoBehaviour
{
    public List<GameObject> monsters;
    float TimeCounter = 0;
    public static int monsCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        monsCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TimeCounter += Time.deltaTime;
        Debug.Log("Monster remine:" + monsCount);

        if (TimeCounter >= 2f && Timer.EndCount==false)//Spawn mons per 1 sec
        {
            float randomX = Random.Range(0, 2) == 0 ? 30f : 30f;
            int randomMonster = Random.Range(0, monsters.Count);

            Instantiate(monsters[randomMonster], new Vector3(randomX, 5f, -1f), transform.rotation);
            TimeCounter = 0;
            monsCount++;
        }

    }
}
