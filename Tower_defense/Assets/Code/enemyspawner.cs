using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class enemyspawner : MonoBehaviour
{

    private GameObject normalEnemy;
    private float lasttimespawned;
    private float spawntime;

	// Use this for initialization
	void Start ()
	{
	    normalEnemy = (GameObject) Resources.Load("prefabs/enemy", typeof(GameObject));
        Debug.Log(normalEnemy.name);
	    lasttimespawned = Time.time;
	    spawntime = 3f;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Time.time - lasttimespawned > spawntime)
	    {
	        Instantiate(normalEnemy, transform);
	        lasttimespawned = Time.time;
	        spawntime = spawntime / 1.1f;
	        if (spawntime < .8f)
	        {
	            spawntime = .8f;
	        }
	    }
	}
}
