using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterSpawn : MonoBehaviour
{
    public GameObject slime;
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

        if (TimeCounter >= 1 && Timer.EndCount==false)//Spawn mons per 1 sec
        {
            float randomX = Random.Range(0, 2) == 0 ? -8f : 15f;
 
            Instantiate(slime, new Vector3(randomX, 0f, -1f), transform.rotation);
            TimeCounter = 0;
            monsCount++;
            //Debug.Log("Generating slime");
        }

    }
}
