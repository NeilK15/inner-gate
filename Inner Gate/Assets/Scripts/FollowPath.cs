using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{

    public Transform path;
    public float distanceError = 0.05f;

    private Transform[] points;
    private int _numPoints;
    private Enemy enemy;

    private void Start()
    {
        if (!path)
        {
            path = GameController.Instance.path;
        }


        // Getting the enemy data;
        enemy = GetComponent<Enemy>();

        _numPoints = path.childCount;

        // Getting the children of the parent game object (the points)

        points = new Transform[_numPoints];

        for (int i = 0; i < _numPoints; i++)
        {
            points[i] = path.GetChild(i);
        }
    }

    private void FixedUpdate()
    {
        // If the enemy can move, then move it

        if (enemy.canMove)
            Move(enemy.enemyData.speed);
    }

    private int _currPoint = 0;

    public void Move(float speed)
    {

        if (_currPoint < _numPoints)
        {
            // Getting the direction to move towards is destination - origin

            Vector3 direction = Vector3.Normalize(points[_currPoint].position - transform.position);

            transform.position += speed * Time.fixedDeltaTime * direction;


            // Continue to move the enemy until it reaches the last point

            if (Vector2.Distance(transform.position, points[_currPoint].position) <= distanceError)
            {
                transform.position = points[_currPoint].position;
                _currPoint++;
            }
        }
    }

}
