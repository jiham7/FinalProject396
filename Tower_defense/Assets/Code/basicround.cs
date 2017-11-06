using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicround : MonoBehaviour
{

    private GameObject target;
    private int damage = 4;//need to set this up better later

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (target != null)
	    {
	        Transform targetposn = target.transform;
	        Rigidbody r = gameObject.GetComponent<Rigidbody>();
	        r.velocity = (targetposn.position - transform.position).normalized * 4;
        }
        else if (transform.position.y < 2 || transform.position.z > 5.5 || transform.position.z > -5.5 ||
                 transform.position.x > 5.5 || transform.position.z > -5.5)
	    {
	        Destroy(gameObject);
	    }

    }

    void Target(GameObject tar)
    {
        target = tar;
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Enemy")//Hit an enemy
        {
            c.gameObject.SendMessage("GotHit", damage);
            Destroy(gameObject);
        }
    }
}
