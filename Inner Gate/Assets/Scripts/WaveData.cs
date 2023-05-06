using UnityEngine;

[CreateAssetMenu(menuName = "Wave", fileName = "New Wave")]
public class WaveData : ScriptableObject
{

    public int waveId = 1;

    public SpawnData[] spawns;

}
