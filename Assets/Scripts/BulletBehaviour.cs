using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {

    public float speed;
    public float damage;
    public GameObject aoe;
    public GameObject target;
    public EnemyBehaviour enemy;

    private float distance;

    private float despawnCounter;
    

    void Start ()
    {
        enemy = target.gameObject.GetComponent<EnemyBehaviour>();
        despawnCounter = 0;
    }

    void Update ()
    {
        if(target == null) despawnCounter += Time.deltaTime;
        else
        {
            // Gets the direction the target is facing
            transform.up = target.transform.position - transform.position;
            // Moves to the target
            gameObject.transform.position = Vector2.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
        }

        // Missiles explode creating an Aoe damage instead of just despawning
        if (despawnCounter > 0.1) DestroyBullet();
    }

    public void DestroyBullet()
    {
        GameObject newAoe = Instantiate(aoe);
        newAoe.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
        Destroy(gameObject);
    }
}
