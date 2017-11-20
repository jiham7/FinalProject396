using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{

    private Slider s;

	void Start ()
	{
	    s = GetComponent<Slider>();
	    s.value = 100;
	}

    public void newValue(float value)
    {
        s.value = value;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
