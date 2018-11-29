using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuild : MonoBehaviour {

    public GameObject tower;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    void OnMouseUp()
    {
        GameObject newTower = Instantiate(tower);

        newTower.transform.localPosition = new Vector3(this.transform.position.x, this.transform.position.y, 0);

        newTower.transform.parent = null;

        Destroy(this.gameObject);
    }


    // Esto no funciona
    public void OnTouch()
    {
        GameObject newTower = Instantiate(tower);

        newTower.transform.localPosition = new Vector3(this.transform.position.x, this.transform.position.y, 0);

        newTower.transform.parent = null;

        Destroy(this.gameObject);
    }

}
