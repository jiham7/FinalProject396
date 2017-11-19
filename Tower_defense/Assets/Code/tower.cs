using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour
{
    private GameObject bullet;
    private int damage;
    private float timebetweenbullets;
    private float timesincelastshot;

	// Use this for initialization
	void Start ()
	{
	    damage = 5;
	    bullet = (GameObject)Resources.Load("prefabs/basicround", typeof(GameObject));
	    timebetweenbullets = 1f;
	    timesincelastshot = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		//find all the enemies
	    GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //find the closest one if it exists
        if (enemies.Length != 0)
	    {
	        GameObject closest = enemies[0];
	        foreach (GameObject e in enemies)
	        {
	            if ((transform.position - e.transform.position).sqrMagnitude <
	                (transform.position - closest.transform.position).sqrMagnitude)
	            {
	                closest = e;
	            }
	        }
            //LOOK AT IT!
	        transform.rotation = Quaternion.LookRotation((closest.transform.position - transform.position).normalized);
            //SHOOOOOOT AT IT BRUH!!!
	        if ((Time.time - timesincelastshot) > timebetweenbullets)
	        {
	            timesincelastshot = Time.time;
                //create shot
	            GameObject newround = Instantiate(bullet, transform);
                newround.SendMessage("Target", closest);
	        }
	    }
	}
}
