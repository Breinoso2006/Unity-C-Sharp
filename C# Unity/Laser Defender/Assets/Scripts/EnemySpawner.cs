using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs; //pega uma lista de ondas
    [SerializeField] int startingWave = 0;
    [SerializeField] float timeBetweenWaves = 0.5f;
    [SerializeField] bool looping = false;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
    }

    //private IEnumerator SpawnAllWaves()
    //{
    //    for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
    //    {
    //        var currentWave = waveConfigs[waveIndex]; //seta a onda atual
    //        yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
    //        yield return new WaitForSeconds(timeBetweenWaves);
    //    }
    //}

    private IEnumerator SpawnAllWaves()
    {
        var currentWave = waveConfigs[Random.Range(0,waveConfigs.Count)]; //seta a onda atual
        yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        yield return new WaitForSeconds(timeBetweenWaves);
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            var newEnemy = Instantiate(
                waveConfig.GetEnemyPrefab(),
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.identity); //spawna o inimigo com seus pontos de movimento
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig); //linka o inimigo com a classe de movimento
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }
}
