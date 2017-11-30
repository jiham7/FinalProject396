using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private int health;

    // Use this for initialization
    void Start ()
	{
	    health = 10;
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (game.theGame.CanUpdate())
	        Pathfinding();
        else
        {      
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
	}

    void GotHit(int value)
    {
        health = health - value;
        CheckDeath();
    }

    void CheckDeath()
    {
        if (health < 0)
        {
            Destroy(gameObject);
            game.m.MoreMoney(10);
        }
    }

    //sets the current velocity to the fastest path to the base
    void Pathfinding()
    {
        //very basic implmentation
        GameObject target = FindObjectOfType<playerbase>().gameObject;
        Transform targetposn = target.transform;
        Rigidbody r = gameObject.GetComponent<Rigidbody>();
        r.velocity = (targetposn.position - transform.position).normalized*1;
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.name == "Base") //we are colliding with the base
        {
            c.gameObject.SendMessage("GotHit", 5);
            Destroy(gameObject);
        }
    }
}
