using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class playerbase : MonoBehaviour
{

    private int health;
    private game Game;
    private Text textobject;

	// Use this for initialization
	void Start ()
	{
	    health = 100;
	    Game = FindObjectOfType<game>();
	    textobject = FindObjectOfType<Text>();
        SetDisplay();
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

    void SetDisplay()
    {
        textobject.text = health.ToString();
    }

    void GotHit(int value)
    {
        health = health - value;
        CheckLoss();
        SetDisplay();
    }

    void CheckLoss()
    {
        if (health < 0)
        {
            Game.Loss();//change me to be something better
        }
    }
}
