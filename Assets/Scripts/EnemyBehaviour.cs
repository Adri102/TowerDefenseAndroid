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

    // Use this for initialization
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
	
	// Update is called once per frame
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

    //
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
}
