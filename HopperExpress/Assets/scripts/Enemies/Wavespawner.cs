using UnityEngine;
using System.Collections;

public class Wavespawner : MonoBehaviour
{
    [SerializeField] public float timeBetweenWaves;
    [SerializeField] private GameObject spawnPoint;

    public Wave[] waves;
    public int currentWaveIndex = 0;

    private bool spawningWave = false;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
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
            MonsterManager enemy = Instantiate(waves[currentWaveIndex].enemies[i], spawnPoint.transform);
            enemy.transform.SetParent(spawnPoint.transform);
            yield return new WaitForSeconds(waves[currentWaveIndex].timeToNextEnemy);
        }

        currentWaveIndex++;
        spawningWave = false;
    }
}

[System.Serializable]
public class Wave
{
    public MonsterManager[] enemies;
    public float timeToNextEnemy;
}
