using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public float startHealth;
    private float health;

    public Image healthBar;
    public GameObject sprite;

    void Start ()
    {
        health = startHealth;
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
            //enemy.transform.localRotation = Quaternion.Euler(0, 0, 0);
            currentTime = Time.time - lastTime;
            //gameObject.transform.Translate(Vector3.forward * Time.deltaTime * speed);
            gameObject.transform.position = Vector2.MoveTowards(transform.position, points[currentPoint].transform.position, Time.deltaTime * speed);
            //enemy.transform.position = Vector2.Lerp(enemy.transform.position, points[currentPoint].transform.position, currentTime / travelTime);
            currentDistance = Vector2.Distance(enemy.transform.position, points[currentPoint].transform.position);

            if((currentDistance < 0.1f))
            {
                if(currentPoint < points.Length - 1)
                {
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
        // Rotates into the next point
        sprite.transform.right = points[currentPoint].transform.position - transform.position;
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
        healthBar.fillAmount = health / startHealth;
        if (health <= 0) Destroy(enemy);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            // Destroys the missile and creates an Aoe
            other.GetComponent<BulletBehaviour>().DestroyBullet();
        }
        if (other.gameObject.tag == "Aoe")
        {
            TakeDamage(other.GetComponent<AoeBehaviour>().damage);
        }

        if (other.gameObject.tag == "Laser")
        {
            TakeDamage(other.GetComponent<LaserBehaviour>().damage);
        }
    }
}
