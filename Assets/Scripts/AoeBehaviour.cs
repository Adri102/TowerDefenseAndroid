using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoeBehaviour : MonoBehaviour
{
    public float damage;

	void Start ()
    {
        Destroy(this.gameObject, 0.5f);
	}
	
	void Update ()
    {
		
	}

    public void DestroyAoe()
    {
        Destroy(gameObject);
    }
}
