using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuild : MonoBehaviour {

    public GameObject missileTower;
    public GameObject kineticTower;
    public GameObject laserTower;
    [SerializeField] bool building = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetMouseButtonDown(0))
        {
            /*building = false;
            missileTower.SetActive(false);
            kineticTower.SetActive(false);
            laserTower.SetActive(false);*/
        }
    }

    void OnMouseUp()
    {
        building = true;
        missileTower.SetActive(true);
        kineticTower.SetActive(true);
        laserTower.SetActive(true);
        /* GameObject newTower = Instantiate(tower);

         newTower.transform.localPosition = new Vector3(this.transform.position.x, this.transform.position.y, 0);

         newTower.transform.parent = null;

         Destroy(this.gameObject);*/
    }


    public void OnTouch()
    {
        building = true;
        missileTower.SetActive(true);
        kineticTower.SetActive(true);
        laserTower.SetActive(true);
        /*
        GameObject newTower = Instantiate(tower);

        newTower.transform.localPosition = new Vector3(this.transform.position.x, this.transform.position.y, 0);

        newTower.transform.parent = null;

        Destroy(this.gameObject);*/
    }

    public void DeleteBuilding()
    {
        Destroy(this.gameObject);
    }

}
