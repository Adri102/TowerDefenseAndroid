using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour {

    public int lives;
    public int maxLives;
    public Text livesText;
	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        if(lives <= 0) lives = 0;

        livesText.text = lives + "/" + maxLives;
	}
}
