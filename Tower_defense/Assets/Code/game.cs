using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class game : MonoBehaviour
{
    private bool gameover = false;
    private Text endText;

	// Use this for initialization
	void Start () {
		endText = GameObject.FindGameObjectWithTag("GameOverText").GetComponent<Text>();
	    endText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //call me if player lost the game
    public void Loss()
    {
        if (!gameover)
        {
            GameStop(0);
        }
    }

    public void Win()
    {
        if (!gameover)
        {
            GameStop(1);
        }
    }

    public void GameStop(int i)
    {
        //players can no longer win or lose
        gameover = true;

        //
        //
        //
        //need to add: freeze money, stop build/destroy towers
        //should be as simple as deleting a componenet
        //
        //

        //Destroys all the shooting components of all the towers
        GameObject[] cannons = GameObject.FindGameObjectsWithTag("Cannon");
        foreach (GameObject c in cannons)
        {
            Destroy(c.GetComponent<tower>());
        }

        //Destoys all the movement and ridgidbody components of enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject e in enemies)
        {
            Destroy(e.GetComponent<enemy>());
            Destroy(e.GetComponent<Rigidbody>());
        }

        //stops spawning stuffs
        GameObject spawner = GameObject.FindGameObjectWithTag("Spawner");
        Destroy(spawner.GetComponent<enemyspawner>());

        //display game over text
        if (i == 0)
        {
            endText.text = "Mastery is a path... You hit a bolder.";
        }
        else
        {
            endText.text = "Mastery is a path... You have crossed the mountian.";
        }
        endText.enabled = true;
    }
}
