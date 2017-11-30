using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class ground : MonoBehaviour {

    private MeshRenderer mesh;
    private Material m;
    private bool hasTower = false;
    private GameObject thisTower;

    // Use this for initialization
    void Start ()
    {
        mesh = GetComponent<MeshRenderer>();
        m = mesh.material;
        if (name.Substring(0, 3).Equals("Red")) 
            m.color = new Color(0.9F, 0, 0);
        else 
            m.color = new Color(1, 1, 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
	}

    public bool GetHasTower()
    {
        return hasTower;
    }

    public void SetHasTower()
    {
        hasTower = !hasTower;
    }

    void OnMouseUp()
    {
        if (game.theGame.CanUpdate() && !name.Equals("Red11") && !name.Equals("Red55"))
            Select();
    }

    void Select()
    {
        game.theGame.DisableEverything();
        if (hasTower)
        {
            game.U.Visible(this);         
        }
        else
        {
            game.B.Visible(this);         
        }
    }

    public void BuildTower()
    {
        thisTower = (GameObject)Instantiate(Resources.Load("prefabs/Tower"), transform.position, new Quaternion(0, 180, 0, 0));
        game.m.MoreMoney(-50);
    }

    public void SellTower()
    {
        Destroy(thisTower.gameObject);
        game.m.MoreMoney(45);
    }

    public void UpgradeTower()
    {
        Destroy(thisTower.gameObject);
        game.m.MoreMoney(-50);
    }
}
