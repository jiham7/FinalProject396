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
    
    //function called by lightning tower that chains to nearby enemies, should be initially passed damage value and an empty array upon the tower firing
    void GotChained(int value, enemy[] alreadyhit){
    	//is only allowed to hit up to 3 enemies in one hit
    	if (alreadyhit.length>2){
		return;
	}
	alreadyhit = alreadyhit + [this];//don't want to hit myself
	//so we are going to find all the ally's of the enemy...
    	GameObject[] allys = gameObject.FindObjectsWithTag("enemy");
	if(allys.length()!=0){
		bool skip;
		//find the closest enemy that this bounce hasn't hit yet
		enemy closest = allys[0].transform.GetComponent<enemy>();
		float sqrclose = 150;//bug fixed :D
		foreach (GameObject a in allys){
			skip = false;
			//make sure it hasn't been hit yet
			foreach (enemy e in alreadyhit){
				if(a.transform.GetComponent<enemey>()==e){
					skip = true;
					break;
				}
			}
			//it hasnt been hit: see if it is closer then the current closest
			if (!skip){
				newdist = (a.transform.position-transform.position).sqrdistance;
				if(sqrclose>newdist){
					closest = a.transform.GetComponent<enemy>();
					sqrclose = newdist;
				}
			}
		}
		//fire at the closest enemy if it is not out of range
		if(sqrclose<max_chain_distance){
			closest.GotChained(value, alreadyhit);
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
