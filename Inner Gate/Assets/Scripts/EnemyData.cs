using UnityEngine;

[CreateAssetMenu(menuName = "New Enemy", fileName = "Enemy")]
public class EnemyData : ScriptableObject
{

    public string name = "Enemy";

    public float speed = 1f;

    public float health = 100f;

    public float damage = 2f;

    public float range = 1f;

    // Attacks per minute
    public int attackSpeed = 30;

    public GameObject prefab;

}
