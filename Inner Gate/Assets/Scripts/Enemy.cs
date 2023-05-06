using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FollowPath))]
public class Enemy : MonoBehaviour
{

    public EnemyData enemyData;

    private GameController _gameController;


    private float _health;

    private float _attackSpeed;

    [HideInInspector]
    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        _gameController = GameController.Instance;
        _health = enemyData.health;
        _attackSpeed = enemyData.attackSpeed / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (InRange())
        {
            // Set can move to false if in range of gate

            canMove = false;

            // Start damaging the gate
            Attack();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, enemyData.range);
    }

    private bool InRange()
    {
        if (Vector2.Distance(transform.position, _gameController.gate.position) <= enemyData.range)
        {
            return true;
        }

        return false;
    }

    private float timeSinceLastAttack = 0f;

    private void Attack()
    {
        if (timeSinceLastAttack > _attackSpeed)
        {
            _gameController.DamageGate(enemyData.damage);
            timeSinceLastAttack = 0f;
        }
        else
        {
            timeSinceLastAttack += Time.deltaTime;
        }
    }

    public void DamageEnemy(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Kill();
        }
    }

    private void Kill()
    {
        // Play death animation and sound

        Destroy(gameObject);
    }
}
