using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnBehaviour : MonoBehaviour {

    public GameObject enemy;
    public GameObject[] points;

    // Use this for initialization
    void Start ()
    {
        enemy.GetComponent<EnemyBehaviour>().points = points;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Space)) Instantiate(enemy, this.transform);
	}
}
