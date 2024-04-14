using System.Collections;
using UnityEngine;

public class MonsterSpawn2 : MonoBehaviour
{
    public GameObject Mons1;
    public GameObject Mons2;
    public GameObject Mons3;

    public static int monsCount = 0;
    public int CurrentWave = 0;
    public int monsLeft = 0;
    public float MonsSpawnRate = 0.5f;
    public GameObject spawnPoint;
    public float nextWaveRate = 5f; 

    void Start()
    {
        StartCoroutine(TimeToNextWave());
    }

    IEnumerator TimeToNextWave()
    {
        while (true) 
        {
            yield return new WaitForSeconds(nextWaveRate);
            CurrentWave++;
            StartCoroutine(MonsSpawn());
        }
    }

    IEnumerator MonsSpawn()
    {
        if (CurrentWave == 1)
        {
            SpawnMons1();
            yield return new WaitForSeconds(MonsSpawnRate);
            SpawnMons1();
        }
        else if (CurrentWave == 2)
        {
            SpawnMons1();
            yield return new WaitForSeconds(MonsSpawnRate);
            SpawnMons1();
            yield return new WaitForSeconds(MonsSpawnRate);
            SpawnMons1();
            yield return new WaitForSeconds(MonsSpawnRate);
            SpawnMons1();
        }
        else if (CurrentWave == 3)
        {
            SpawnMons1();
            yield return new WaitForSeconds(MonsSpawnRate);
            SpawnMons1();
            yield return new WaitForSeconds(MonsSpawnRate);
            SpawnMons1();
            yield return new WaitForSeconds(MonsSpawnRate);
            SpawnMons2();
        }
        else if (CurrentWave == 4)
        {
            SpawnMons1();
            yield return new WaitForSeconds(MonsSpawnRate);
            SpawnMons1();
            yield return new WaitForSeconds(MonsSpawnRate);
            SpawnMons2();
            yield return new WaitForSeconds(MonsSpawnRate);
            SpawnMons2();
            yield return new WaitForSeconds(MonsSpawnRate);
            SpawnMons1();
        }
        else if (CurrentWave == 5)
        {
            SpawnMons1();
            yield return new WaitForSeconds(MonsSpawnRate);
            SpawnMons1();
            yield return new WaitForSeconds(MonsSpawnRate);
            SpawnMons1();
            yield return new WaitForSeconds(MonsSpawnRate);
            SpawnMons1();
            yield return new WaitForSeconds(MonsSpawnRate);
            SpawnMons1();
        }
        else if (CurrentWave == 6)
        {
            SpawnMons2();
            yield return new WaitForSeconds(MonsSpawnRate);
            SpawnMons2();
            yield return new WaitForSeconds(MonsSpawnRate);
            SpawnMons1();
            yield return new WaitForSeconds(MonsSpawnRate);
            SpawnMons2();
            yield return new WaitForSeconds(MonsSpawnRate);
            SpawnMons1();
            yield return new WaitForSeconds(MonsSpawnRate);
            SpawnMons1();
        }

    }

    void SpawnMons1()
    {
        Instantiate(Mons1, spawnPoint.transform.position, Quaternion.identity);
        monsCount++;
    }

    void SpawnMons2()
    {
        Instantiate(Mons2, spawnPoint.transform.position, Quaternion.identity);
        monsCount++;
    }

    void SpawnMons3()
    {
        Instantiate(Mons3, spawnPoint.transform.position, Quaternion.identity);
        monsCount++;
    }
}
