using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game : MonoBehaviour {

    public static game theGame;
    public static Healthbar h;
    public static money m;
    public static Build B;
    public static Upgrade U;
    private bool canUpdate = true;
    private Text endText;
    private bool gameover = false;

    // Use this for initialization
    void Start ()
    {
        theGame = this;
        h = GameObject.Find("Slider").GetComponent<Healthbar>();
        m = GameObject.Find("MoneyText").GetComponent<money>();
        endText = GameObject.FindGameObjectWithTag("GameOverText").GetComponent<Text>();
        endText.enabled = false;
    }
	
	// Update is called once per frame
    public bool CanUpdate()
    {
        return canUpdate;
    }

    public void DisableEverything()
    {
        canUpdate = false;
    }

    public void EnableEverything()
    {
        canUpdate = true;
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

        //stop spending money and bulding/destroying towers by destroying that option
        Destroy(h.gameObject);
        Destroy(m.gameObject);

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
