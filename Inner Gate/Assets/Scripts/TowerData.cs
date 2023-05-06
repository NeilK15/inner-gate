using UnityEngine;

[CreateAssetMenu(menuName = "Towers/TowerData", fileName = "New Tower Data")]
public class TowerData : ScriptableObject
{

    public new string name;

    public Sprite icon;

    public int cost;

    public float damage;

    public float fireRate;

    public float range;

    public GameObject prefab;

}
