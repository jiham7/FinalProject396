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
    private MeshRenderer mesh;
    private Material m;

    // Use this for initialization
    void Start ()
	{
	    health = 100;
	    Game = FindObjectOfType<game>();
	    textobject = GameObject.FindGameObjectWithTag("HealthText").GetComponent<Text>();
        mesh = GetComponent<MeshRenderer>();
	    m = mesh.material;
        m.color = Color.green;
	    //SetDisplay();
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

    /*void SetDisplay()
    {
        textobject.text = health.ToString();
    }*/

    void GotHit(int value)
    {
        health = health - value;
        game.h.newValue(health);
        CheckLoss();
        //SetDisplay();
    }

    void CheckLoss()
    {
        if (health < 0)
        {
            Game.Loss();
            Destroy(this);//stop updating
        }
    }
}
