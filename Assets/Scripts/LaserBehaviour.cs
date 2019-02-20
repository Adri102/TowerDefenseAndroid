using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    //public float damageRate;
    //public float damageRateCounter;
    public float damage;
    public float speed;
    public GameObject target;
    public EnemyBehaviour enemy;
    public Vector3 direction;

    public Rigidbody2D body;

    private float despawnCounter;
    
    void Start ()
    {
        enemy = target.gameObject.GetComponent<EnemyBehaviour>();
        //damageRate = 1f;
        //damageRateCounter = 0;
        despawnCounter = 0;
        // Gets the direction the target is facing and applies a force to move forward
        transform.right = target.transform.position - transform.position;
        direction = target.transform.position;
        body.AddRelativeForce(transform.right * speed, ForceMode2D.Impulse);
    }

    void Update ()
    {
        // Despawn Logic, movement made with the rigidbody
        despawnCounter += Time.deltaTime;
        if (despawnCounter > 3) Destroy(gameObject);
    }

    // Never used, created just in case
    public void DestroyLaser()
    {
        Destroy(gameObject);
    }
}
