using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float timeBetweenWaves = 5f;
    public int enemiesPerWave = 3;

    private int waveNumber = 1;
    private int enemiesAlive = 0;

    void Start()
    {
        StartCoroutine(ManageWaves());
    }

    IEnumerator ManageWaves()
    {
        while (true)
        {
            yield return StartCoroutine(SpawnWave());

            // Wait until all enemies are dead
            while (enemiesAlive > 0)
            {
                yield return null;
            }

            enemiesPerWave += 2;
            waveNumber++;
            HUDManager.instance.UpdateWave(waveNumber); // optional: move this to top
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < enemiesPerWave; i++)
        {
            Transform spawn = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(enemyPrefab, spawn.position, Quaternion.identity);
            enemiesAlive++;
            HUDManager.instance.UpdateEnemiesAlive(enemiesAlive);
            yield return new WaitForSeconds(0.2f); // slight delay to avoid instant swarm
        }
    }

    public void EnemyDied()
    {
        enemiesAlive--;
        HUDManager.instance.UpdateEnemiesAlive(enemiesAlive);
    }
}
