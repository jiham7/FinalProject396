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
    
    //function called by lightning tower that chains to nearby enemies
    void GotChained(int value, enemy[] alreadyhit){
    	GameObject[] allys = gameObject.FindObjectsWithTag("enemy");
	if(allys.length()!=0){
		bool skip;
		//find the closest enemy that this bounce hasn't hit yet
		enemy closest = allys[0].transform.GetComponent<enemy>();
		float sqrclose = (closest.transform.position-transform.position).sqrdistance;
		foreach (GameObject a in allys){
			skip = false;
			foreach (enemy e in alreadyhit){
				if(a.transform.GetComponent<enemey>()==e){
					skip = true;
					break;
				}
			}
			if (!skip){
				newdist = (a.transform.position-transform.position).sqrdistance;
				if(sqrclose>newdist){
					closest = a.transform.GetComponent<enemy>();
					sqrclose = newdist;
				}
			}
		}
		if(sqrclose<max_chain_distance){
			closest.GotChained(value, alreadyhit + [this]);
		}
	}
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
