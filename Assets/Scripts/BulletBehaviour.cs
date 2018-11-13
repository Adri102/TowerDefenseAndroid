using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {

    public float speed;
    public float damage;
    public GameObject target;
    public EnemyBehaviour enemy;
    public Vector3 startPosition;
    public Vector3 targetPosition;

    private float distance;
    private float startTime;

    // private GameManagerBehavior gameManager;

    void Start ()
    {
        startTime = Time.time;
        distance = Vector2.Distance(startPosition, targetPosition);
        enemy = target.gameObject.GetComponent<EnemyBehaviour>();
        //GameObject gm = GameObject.Find("GameManager");
        // gameManager = gm.GetComponent<GameManagerBehavior>();
    }

    void Update ()
    {
        // 1 
        float timeInterval = Time.time - startTime;
        gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, timeInterval * speed / distance);

        // 2 
        if(gameObject.transform.position.Equals(targetPosition))
        {
            if(target != null)
            {
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }

    }
}
