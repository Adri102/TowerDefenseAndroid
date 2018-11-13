using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerShoot : MonoBehaviour {

    public List<GameObject> enemiesInRange;
    public GameObject bullet;
    public GameObject target;

    private float distanceTarget = 100;


    void Start ()
    {
        enemiesInRange = new List<GameObject>();
        bullet.gameObject.GetComponent<BulletBehaviour>().startPosition = gameObject.transform.position;
    }


    void Update ()
    {
        // Checks there is an enemy in range
		if (enemiesInRange.Count >= 1)
        {
            // Checks the enemy closer to exit the map and targets it
            for(int i = 0; i < enemiesInRange.Count; i++)
            {
                if(enemiesInRange[i].gameObject.GetComponent<EnemyBehaviour>().DistanceToExit() < distanceTarget)
                {
                    distanceTarget = enemiesInRange[i].gameObject.GetComponent<EnemyBehaviour>().DistanceToExit();
                    target = enemiesInRange[i];
                    bullet.gameObject.GetComponent<BulletBehaviour>().target = target;
                    bullet.gameObject.GetComponent<BulletBehaviour>().targetPosition = target.transform.position;
                }
            }

            GameObject newBullet = Instantiate(bullet, this.transform);
        }
	}

    void OnEnemyDestroy(GameObject enemy)
    {
        enemiesInRange.Remove(enemy);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag =="Enemy")
        {
            enemiesInRange.Add(other.gameObject);
            // EnemyDestructionDelegate del = other.gameObject.GetComponent<EnemyDestructionDelegate>();
            //del.enemyDelegate += OnEnemyDestroy;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Remove(other.gameObject);
            // EnemyDestructionDelegate del = other.gameObject.GetComponent<EnemyDestructionDelegate>();
            //del.enemyDelegate -= OnEnemyDestroy;
        }
    }

}
