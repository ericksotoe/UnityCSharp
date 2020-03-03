using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;

    // Start is called before the first frame update
    IEnumerator Start() {
        do {
            yield return StartCoroutine(SpawnAllWaves());
        } while (looping);

    }

    // this method grabs each individual wave and passes it to the spawn wave coroutine
    private IEnumerator SpawnAllWaves() {
        for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++) {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }

    // this method uses the currentwave config to instantiate the enemy onto the game and move it depending on waypoints
    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig) {

        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++) {
            var newEnemy = Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWaypoints()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            float delay = waveConfig.GetTimeBetweenSpawns() + UnityEngine.Random.Range(0f, waveConfig.GetSpawnRandomFactor());
            yield return new WaitForSeconds(delay);
        }
    }
}
