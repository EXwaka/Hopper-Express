using UnityEngine;
using System.Collections;

public class Wavespawner : MonoBehaviour
{
    [SerializeField] public float timeBetweenWaves;
    [SerializeField] private GameObject spawnPointR;
    [SerializeField] private GameObject spawnPointL;

    public float waitWhenStart=0;
    private bool waitEnd=false;

    private int consecutiveSpawns = 0; // �s��ͦ����p�ƾ�
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

            float randomZ = Mathf.Round(Random.Range(-2.5f, 2.5f) * 10) / 10f;//�i�� �קK�t�Z�L�p
            Vector3 spawnPos = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z+randomZ);
            MonsterManager enemy = Instantiate(waves[currentWaveIndex].enemies[i], spawnPos, Quaternion.identity);
            monsCount++;

            enemy.transform.SetParent(spawnPoint.transform);

            if (spawnPoint == lastSpawnPoint)
            {
                consecutiveSpawns++; // �P�@�ͦ��I�s��ͦ�
            }
            else
            {
                consecutiveSpawns = 1; // ���m�p�ƾ�
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
            // �p�G�s��ͦ��F��̤j���ơA�j��q�t�@�ӥͦ��I�ͦ�
            return lastSpawnPoint == spawnPointL ? spawnPointR : spawnPointL;
        }
        else
        {
            // ���`�H����ܥͦ��I
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