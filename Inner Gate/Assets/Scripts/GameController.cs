
using UnityEngine;

public class GameController : MonoBehaviour
{

    #region Singleton

    public static GameController Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    #endregion

    public Transform gate;

    public Transform path;

    public float gateHealth = 1000f;

    public void DamageGate(float damage)
    {
        gateHealth -= damage;

        if (gateHealth <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        Debug.Log("Game Over");
    }
}
