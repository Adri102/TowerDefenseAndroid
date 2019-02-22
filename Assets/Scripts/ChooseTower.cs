using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseTower : MonoBehaviour {

    public GameObject missileType;
    public GameObject kineticType;
    public GameObject laserType;
    public TowerBuild builder;
    [SerializeField] GameObject selectedType;

    // Use this for initialization
    void Start()
    {
        if(this.tag == "BuildMissile") selectedType = missileType;
        else if(this.tag == "BuildKinetic") selectedType = kineticType;
        else if(this.tag == "BuildLaser") selectedType = laserType;
        else selectedType = null;
    }
    void OnMouseUp()
    {
        if(selectedType != null)
        {
            GameObject newTower = Instantiate(selectedType);

            newTower.transform.localPosition = new Vector3(this.transform.position.x, this.transform.position.y, 0);

            newTower.transform.parent = null;

            builder.DeleteBuilding();
        }
    }


    public void OnTouch()
    {
        if(selectedType != null)
        {
            GameObject newTower = Instantiate(selectedType);

            newTower.transform.localPosition = new Vector3(this.transform.position.x, this.transform.position.y, 0);

            newTower.transform.parent = null;
            builder.DeleteBuilding();
        }
    }
}
