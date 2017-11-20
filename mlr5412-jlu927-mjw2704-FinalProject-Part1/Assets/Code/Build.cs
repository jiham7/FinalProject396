using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Build : MonoBehaviour
{
    private Button resumeButton;
    private Button buildButton;
    ground currentGround;
    private bool enoughMoney = true;
    // Use this for initialization
    void Start()
    {
        game.B = GameObject.FindWithTag("Build").GetComponent<Build>();
        InitializeButtons();
        gameObject.SetActive(false);       
    }

    // Update is called once per frame
    void Update()
    {
        if (game.m.MoneyAmount() >= 50)
        {
            enoughMoney = true;
            buildButton.interactable = true;
        }
        else
        {
            enoughMoney = false;
            buildButton.interactable = false;
        }
    }

    public void Visible(ground g)
    {
        gameObject.SetActive(true);
        currentGround = g;
    }

    void InitializeButtons()
    {
        resumeButton = GameObject.Find("ResumeB").gameObject.GetComponent<Button>();
        resumeButton.onClick.AddListener(Resume);
        buildButton = GameObject.Find("Buy").gameObject.GetComponent<Button>();
        buildButton.onClick.AddListener(Buy);
    }

    void Resume()
    {
        gameObject.SetActive(false);
        game.theGame.EnableEverything();
    }

    void Buy()
    {
        if (CanBuildHere(currentGround))
        {
            currentGround.BuildTower();
            currentGround.SetHasTower();
            gameObject.SetActive(false);
            game.theGame.EnableEverything();
        }
    }

    bool CanBuildHere(ground g)
    {
        return true;
    }
}
