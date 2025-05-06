using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    public int enemiesPerWave = 3;

    private int waveNumber = 1;

    void Start()
    {
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        while (true)
        {
            HUDManager.instance.UpdateWave(waveNumber);

            for (int i = 0; i < enemiesPerWave; i++)
            {
                Transform spawn = spawnPoints[Random.Range(0, spawnPoints.Length)];
                Instantiate(enemyPrefab, spawn.position, Quaternion.identity);
            }

            enemiesPerWave += 2; // Increase difficulty
            waveNumber++;

            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }
}
