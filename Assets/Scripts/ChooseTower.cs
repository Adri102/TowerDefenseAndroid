using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseTower : MonoBehaviour {

    public GameObject missileType;
    public GameObject kineticType;
    public GameObject laserType;
    public TowerBuild builder;
    public PlayerBehaviour player;
    [SerializeField] GameObject selectedType;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
        if(this.tag == "BuildMissile") selectedType = missileType;
        else if(this.tag == "BuildKinetic") selectedType = kineticType;
        else if(this.tag == "BuildLaser") selectedType = laserType;
        else selectedType = null;
    }
    void OnMouseUp()
    {
        if(selectedType != null && CheckPrices(player.money))
        {
            GameObject newTower = Instantiate(selectedType);

            TakeMoney();
            newTower.transform.localPosition = new Vector3(this.transform.parent.position.x, this.transform.parent.position.y, 0);

            newTower.transform.parent = null;

            builder.DeleteBuilding();
        }
    }


    public void OnTouch()
    {
        if (selectedType != null)
        {
            GameObject newTower = Instantiate(selectedType);

            TakeMoney();
            newTower.transform.localPosition = new Vector3(this.transform.parent.position.x, this.transform.parent.position.y, 0);

            newTower.transform.parent = null;
            builder.DeleteBuilding();
        }
    }

    public bool CheckPrices(int currentMoney)
    {
        if (this.tag == "BuildMissile" && currentMoney>= 200) return true;
        else if (this.tag == "BuildKinetic" && currentMoney>= 150) return true;
        else if (this.tag == "BuildLaser" && currentMoney>= 300) return true;
        else return false;
    }

    public void TakeMoney()
    {
        if(this.tag == "BuildMissile") player.ChangeMoney(-200);
        else if(this.tag == "BuildKinetic") player.ChangeMoney(-150);
        else if(this.tag == "BuildLaser") player.ChangeMoney(-300);
    }

}
