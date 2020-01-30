using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyWaveSpawner : MonoBehaviour
{
    public static EnemyWaveSpawner instance;

    public List<string> enemyTag;
    public List<Transform> spawnList;
    private int enemyNumber;

    public int totalWaves = 10;
    private int currentWave = 0;

    public int totalEnemyNumber;
    public int currentEnemy;

    private bool spawnEnemies;
    [SerializeField] private Text waveText = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        spawnEnemies = true;
        currentWave++;
        waveText.text = "Wave: " + currentWave;
    }

    private void Update()
    {
        if (currentWave < totalWaves + 1)
        {
            if (spawnEnemies)
            {
                SpawnEnemy();
            }
            if (currentEnemy >= totalEnemyNumber)
            {
                spawnEnemies = false;
            }
        }
    }

    void SpawnEnemy()
    {
        enemyNumber = Random.Range(0, enemyTag.Capacity);
        GameObject enemy = ObjectPooler.instance.GetPooledObject(enemyTag[enemyNumber]);
        if(enemy != null)
        {
            enemy.transform.position = spawnList[Random.Range(0, spawnList.Capacity)].transform.position;
            currentEnemy++;
            enemy.SetActive(true);
        }
    }

    public void CheckWave()
    {
        if (currentEnemy == 0)
        {
            spawnEnemies = true;
            totalEnemyNumber += 1;
            currentWave++;
            waveText.text = "Wave: " + currentWave;
        }
    }
}
