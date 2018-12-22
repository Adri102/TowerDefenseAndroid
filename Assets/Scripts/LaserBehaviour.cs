using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    public float damageRate;
    public float damageRateCounter;
    public float damage;
    public GameObject target;
    public EnemyBehaviour enemy;

    private float despawnCounter;
    
    void Start ()
    {
        enemy = target.gameObject.GetComponent<EnemyBehaviour>();
        damageRate = 1f;
        damageRateCounter = 0;
        despawnCounter = 0;
    }

    void Update ()
    {
        if (target == null) despawnCounter += Time.deltaTime;
        else
        {
            transform.right = target.transform.position - transform.position;
        }

        if (despawnCounter > 0.1) Destroy(gameObject);
    }

    public void DestroyLaser()
    {
        Destroy(gameObject);
    }
}
