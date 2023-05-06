using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{

    public WaveData[] waves;

    private void Start()
    {
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waves.Length; i++)
        {
            foreach (SpawnData spawn in waves[i].spawns)
            {
                if (spawn.spawns)
                {
                    ClusterData cluster = (ClusterData)spawn;
                    for (int j = 0; j < cluster.num; j++)
                    {
                        Spawn(cluster.enemy);
                        yield return new WaitForSeconds(cluster.delayBetweenSpawns);
                    }
                }
                else
                {
                    yield return new WaitForSeconds(((DelayData)spawn).delay);
                }
            }
        }
    }

    void Spawn(EnemyData enemy)
    {
        Instantiate(enemy.prefab, transform.position, Quaternion.identity);
    }

}
