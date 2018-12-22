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
        //transform.rotation = Quaternion.Euler(0, 0, 0);
        if(target == null) despawnCounter += Time.deltaTime;
        else
        {
            // 1 
            //gameObject.transform.LookAt(target.transform);
            transform.up = target.transform.position - transform.position;
            //gameObject.transform.Translate(Vector3.forward * Time.deltaTime * speed);
            gameObject.transform.position = Vector2.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);

            //transform.rotation = Quaternion.Euler(0, 0, 0);
            // 2 
            /*if(gameObject.transform.position == targetPosition)
            {
                if(target != null)
                {
                    enemy.TakeDamage(damage);
                }
                Destroy(gameObject);
            }*/
        }

        if (despawnCounter > 0.1) Destroy(gameObject);
    }

    public void DestroyBullet()
    {
        GameObject newAoe = Instantiate(aoe);
        newAoe.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
        Destroy(gameObject);
    }
}
