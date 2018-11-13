using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour {

    public int lives;
    public int maxLives;
    public Text livesText;

	void Start ()
    {

	}

	void Update ()
    {
        if(lives <= 0) lives = 0;

        livesText.text = lives + "/" + maxLives;
	}
}
