using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public TowerData towerData;

    public float rotationSmoothing = 0.05f;

    private Transform _targetEnemy;

    void Update()
    {

        CheckForEnemies();

        LookAtEnemy();
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, towerData.range);
    }


    private void CheckForEnemies()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, towerData.range);

        float minDistance = float.MaxValue;

        if (enemies != null && enemies.Length > 0)
        {
            foreach (Collider2D enemy in enemies)
            {
                float distance = Vector2.Distance(transform.position, enemy.transform.position);

                minDistance = Mathf.Min(minDistance, distance);

                if (minDistance == distance)
                {
                    _targetEnemy = enemy.transform;
                }
            }
        } else
        {
            _targetEnemy = null;
        }
    }


    private void LookAtEnemy()
    {
        if (_targetEnemy)
        {
            Vector3 direction = _targetEnemy.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion newRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotationSmoothing);
        }
    }

}
