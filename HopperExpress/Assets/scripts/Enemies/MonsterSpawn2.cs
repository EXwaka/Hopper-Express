using System.Collections;
using UnityEngine;

public class MonsterSpawn2 : MonoBehaviour
{
    public enum SpawnStage { SPAWNING, WAITING, COUNTING};
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }
    public Wave[] waves;
    public int nextWave=0;
    public float timeBetweenWaves = 5f;
    public float waveCountdown;
    public float spawnRate = 0.5f;
    public GameObject SpawnPoint;
    private SpawnStage stage= SpawnStage.COUNTING;
    private bool EnemiesIsNotAlive = true;

    void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    void Update()
    {
        Debug.Log("Wave countdown"+waveCountdown);

        if (stage== SpawnStage.WAITING)
        {
            if(EnemiesIsNotAlive)
            {
                WaveComplete();
            }
            else
            {
                return;
            }

        }
        if (waveCountdown <= 0)
        {
            if(stage!=SpawnStage.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;

        }
    }
    void WaveComplete()
    {
        Debug.Log("Level complete");
        stage = SpawnStage.COUNTING;
        waveCountdown = timeBetweenWaves;
        if (nextWave + 1 > waves.Length - 1)
        {
            Destroy(gameObject);
        }
        else
        {
            nextWave++;

        }

    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Starting Wave:"+_wave.name);
        stage = SpawnStage.SPAWNING;
        for (int i = 0; i < _wave.count; i++)
        {
            SpawnMons(_wave.enemy);
            yield return new WaitForSeconds(spawnRate);
        }
        stage = SpawnStage.WAITING;
    }

    void SpawnMons(Transform _enemy)
    {
        Debug.Log("Spawning enemy:"+_enemy.name);
        Instantiate(_enemy,SpawnPoint.transform.position,transform.rotation);
    }
}
