using UnityEngine;
using System.Collections;

public class Wavespawner : MonoBehaviour
{
    [SerializeField] public float timeBetweenWaves;
    [SerializeField] private GameObject spawnPointR;
    [SerializeField] private GameObject spawnPointL;

    public float waitWhenStart=0;
    private bool waitEnd=false;

    private int consecutiveSpawns = 0; // 連續生成的計數器
    public int maxConsecutiveSpawns = 4;

    public static int monsCount = 0;
    public Wave[] waves;
    public int currentWaveIndex = 0;

    private GameObject lastSpawnPoint;

    private bool spawningWave = false;

    //public void Update()
    //{
    //    Debug.Log("MonsCount:" + monsCount);
    //}

    private void Start()
    {
        monsCount = 0;
        waitEnd = false;

    }

    void Update()
    {
        //Debug.Log("monsLeft"+monsCount);
        waitWhenStart += Time.deltaTime;
        if (waitWhenStart >= 2&&!waitEnd)
        {
            StartCoroutine(SpawnWaves());
            waitEnd = true;
        }
    }

    private IEnumerator SpawnWaves()
    {
        while (currentWaveIndex < waves.Length)
        {
            yield return StartCoroutine(SpawnWave());
            yield return new WaitForSeconds(timeBetweenWaves);
        }

        //Debug.Log("You survived every wave!");
    }

    private IEnumerator SpawnWave()
    {
        spawningWave = true;

        for (int i = 0; i < waves[currentWaveIndex].enemies.Length; i++)
        {
            GameObject spawnPoint = GetSpawnPoint();

            float randomZ = Mathf.Round(Random.Range(-2.5f, 2.5f) * 10) / 10f;//進位 避免差距過小
            Vector3 spawnPos = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z+randomZ);
            MonsterManager enemy = Instantiate(waves[currentWaveIndex].enemies[i], spawnPos, Quaternion.identity);
            monsCount++;

            enemy.transform.SetParent(spawnPoint.transform);

            if (spawnPoint == lastSpawnPoint)
            {
                consecutiveSpawns++; // 同一生成點連續生成
            }
            else
            {
                consecutiveSpawns = 1; // 重置計數器
            }

            lastSpawnPoint = spawnPoint;
            yield return new WaitForSeconds(waves[currentWaveIndex].timeToNextEnemy);
        }

        currentWaveIndex++;
        spawningWave = false;
    }
    private GameObject GetSpawnPoint()
    {
        if (consecutiveSpawns >= maxConsecutiveSpawns)
        {
            // 如果連續生成達到最大次數，強制從另一個生成點生成
            return lastSpawnPoint == spawnPointL ? spawnPointR : spawnPointL;
        }
        else
        {
            // 正常隨機選擇生成點
            return Random.Range(0, 2) == 0 ? spawnPointL : spawnPointR;
        }
    }
}

[System.Serializable]
public class Wave
{
    public MonsterManager[] enemies;
    public float timeToNextEnemy;
}