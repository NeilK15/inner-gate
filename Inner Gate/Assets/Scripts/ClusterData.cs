using UnityEngine;

[CreateAssetMenu(menuName = "Spawn/Cluster", fileName = "New Cluster")]
public class ClusterData : SpawnData
{

    public EnemyData enemy;

    public int num = 10;

    public float delayBetweenSpawns = 0.5f;

}
