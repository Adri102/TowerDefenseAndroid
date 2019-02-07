using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    public float damageRate;
    public float damageRateCounter;
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
        damageRate = 1f;
        damageRateCounter = 0;
        despawnCounter = 0;
        transform.right = target.transform.position - transform.position;
        direction = target.transform.position;
        body.AddRelativeForce(new Vector2(speed, speed), ForceMode2D.Impulse);
    }

    void Update ()
    {

        if(target == null) despawnCounter += Time.deltaTime;
        else
        {
            //transform.right = direction - transform.position;

            //transform.Translate(transform.forward * speed * Time.deltaTime);

            //transform.position = Vector2.MoveTowards(transform.position, direction, Time.deltaTime * speed);

            //body.AddRelativeForce(new Vector2(speed, speed), ForceMode2D.Force);
        }

        despawnCounter += Time.deltaTime;
        if (despawnCounter > 3) Destroy(gameObject);
    }

    public void DestroyLaser()
    {
        Destroy(gameObject);
    }
}
