using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour {

    public int lives;
    public int maxLives;
    public Text livesText;
    public int money;
    public Text moneyText;

	void Start ()
    {

	}

	void Update ()
    {
        if(lives <= 0) lives = 0;
        if(money <= 0) money = 0;

        livesText.text = lives + "/" + maxLives;
        moneyText.text ="" + money;
    }

    public void ChangeMoney(int value)
    {
        money += value;
    }
}
