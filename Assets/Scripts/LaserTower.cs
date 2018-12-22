using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTower : MonoBehaviour
{
    public List<GameObject> enemiesInRange;
    public GameObject target;
    public GameObject laser;

    private float distanceTarget = 100;

    //public float fireRate;
    //public float damage;

    //private float fireRateCounter;
    
    void Start()
    {
        enemiesInRange = new List<GameObject>();
        //fireRateCounter = 0;
    }
    
    void Update()
    {
        //fireRateCounter += Time.deltaTime;

        // Checks there is an enemy in range
        if (enemiesInRange.Count >= 1 /*&& (fireRateCounter >= fireRate)*/)
        {
            CheckEnemiesInRange();
            // Checks the enemy closer to exit the map and targets it
            for (int i = 0; i < enemiesInRange.Count; i++)
            {
                if (enemiesInRange[i].gameObject.GetComponent<EnemyBehaviour>().DistanceToExit() < distanceTarget)
                {
                    distanceTarget = enemiesInRange[i].gameObject.GetComponent<EnemyBehaviour>().DistanceToExit();
                    target = enemiesInRange[i];
                    GameObject newLaser = Instantiate(laser);
                    newLaser.GetComponent<LaserBehaviour>().target = target;
                    newLaser.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
                    distanceTarget = 100;
                    //fireRateCounter = 0;
                    //Debug.Log("Kinetic shoot");
                }
            }
        }
        else target = null;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemiesInRange.Add(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Remove(other.gameObject);
        }
    }

    public void CheckEnemiesInRange()
    {
        for (int i = 0; i < enemiesInRange.Count; i++)
        {
            if (enemiesInRange[i] == null) enemiesInRange.Remove(enemiesInRange[i]);
        }
    }
}
