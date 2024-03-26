using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn2 : MonoBehaviour
{
    public GameObject Mons1;
    public GameObject Mons2;
    public GameObject Mons3;
    float TimeCounter = 0;
    float worldTime = 0;
    public static int monsCount = 0;
    public bool Wave1 = false;
    public bool Wave2 = false;
    public bool Wave3 = false;
    public float wave1EndsIn = 15;
    public float wave2EndsIn = 25;
    public float wave3EndsIn = 30;
    public int monsLeft = 3;
    bool monsLeftIncremented = false; 

    void Start()
    {
        Wave1 = false;
        Wave2 = false;
        Wave3 = false;
        monsCount = 0;
    }

    void Update()
    {
        TimeCounter += Time.deltaTime;
        worldTime += Time.deltaTime;

        if (worldTime >= 5 && worldTime <= wave1EndsIn)
        {
            Wave1 = true;
        }
        else if (worldTime >= wave1EndsIn && worldTime <= wave2EndsIn)
        {
            Wave1 = false;
            Wave2 = true;
            if (!monsLeftIncremented)
            {
                monsLeft += 3;
                monsLeftIncremented = true;
            }
        }
        else if (worldTime >= wave2EndsIn && worldTime <= wave3EndsIn)
        {

            Wave3 = true;
            Wave2 = false;
            if (monsLeftIncremented) 
            {
                monsLeft += 3;
                monsLeftIncremented = false;
            }
        }

        if (TimeCounter >= 2f && Wave1 == true && Timer.EndCount == false && monsLeft >= 1)
        {
            float randomX = Random.Range(0, 2) == 0 ? 30f : 30f;

            Instantiate(Mons1, new Vector3(randomX, 5f, -1f), transform.rotation);
            TimeCounter = 0;
            monsCount++;
            monsLeft -= 1;
        }
        else if (TimeCounter >= 2f && Wave2 == true && Timer.EndCount == false && monsLeft >= 1)
        {
            float randomX = Random.Range(0, 2) == 0 ? 30f : 30f;
            if (monsLeft >= 2)
            {
                Instantiate(Mons1, new Vector3(randomX, 5f, -1f), transform.rotation);
            }
            else
            {
                Instantiate(Mons2, new Vector3(randomX, 5f, -1f), transform.rotation);
            }
            TimeCounter = 0;
            monsCount++;
            monsLeft -= 1;
        }
        else if (TimeCounter >= 2f && Wave3 == true && Timer.EndCount == false && monsLeft >= 1)
        {
            float randomX = Random.Range(0, 2) == 0 ? 30f : 30f;
            if (monsLeft >= 2)
            {
                Instantiate(Mons2, new Vector3(randomX, 5f, -1f), transform.rotation);
            }
            else
            {
                Instantiate(Mons3, new Vector3(randomX, 5f, -1f), transform.rotation);
            }
            TimeCounter = 0;
            monsCount++;
            monsLeft -= 1;
        }
    }
}
