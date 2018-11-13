using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public PlayerBehaviour player;
    public EnemySpawnBehaviour spawn;

    public GameObject enemy;
    public GameObject[] points;

    private int startPoint = 0;

    [SerializeField]    int endPoint;
    [SerializeField]    int currentPoint;

    public float speed;
    public float distance;
    public float currentDistance;
    public float travelTime;
    public float lastTime;
    public float currentTime;
    public float health;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
        endPoint = points.Length;
        currentPoint = 0;
        distance = Vector2.Distance(enemy.transform.position, points[currentPoint].transform.position);
        travelTime = distance / speed;
        lastTime = Time.time;
        RotateDirection();
    }

	void Update ()
    {
        if(!spawn.gameOver)
        {
            currentTime = Time.time - lastTime;
            enemy.transform.position = Vector2.Lerp(enemy.transform.position, points[currentPoint].transform.position, currentTime / travelTime);
            currentDistance = Vector2.Distance(enemy.transform.position, points[currentPoint].transform.position);

            if((currentDistance < 0.1f))
            {
                if(currentPoint < points.Length - 1)
                {
                    Debug.Log("point");
                    currentPoint++;
                    lastTime = Time.time;
                    RotateDirection();
                    distance = Vector3.Distance(enemy.transform.position, points[currentPoint].transform.position);
                }
                else
                {
                    player.lives -= 1;
                    Destroy(enemy);
                }

            }
        }
	}

    private void RotateDirection()
    {
        // Double check, was giving erros dunno why
        if(currentPoint < points.Length - 1)
        {
            // Difference between point and enemy
            Vector3 diff = (points[currentPoint].transform.position - enemy.transform.position);

            // ATan2 Returns the angle in radians whose Tan is y/x, ignoring negatives numbers or /0 errors
            float angle = Mathf.Atan2(diff.y, diff.x);

            // Set rotation. 
            enemy.transform.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg);
        }

    }

    public float DistanceToExit()
    {
        float distance = 0;
        distance += Vector2.Distance(gameObject.transform.position, points[currentPoint + 1].transform.position);
        for(int i = currentPoint + 1; i < points.Length - 1; i++)
        {
            Vector3 startPosition = points[i].transform.position;
            Vector3 endPosition = points[i + 1].transform.position;
            distance += Vector2.Distance(startPosition, endPosition);
        }
        return distance;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0) Destroy(enemy);
    }
}
