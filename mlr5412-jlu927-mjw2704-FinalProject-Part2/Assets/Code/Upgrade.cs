using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    private Button resumeButton;
    private Button sellButton;
    private Button upgradeButton;
    ground currentGround;
    private bool enoughMoney = false;
    // Use this for initialization
    void Start()
    {
        game.U = GameObject.FindWithTag("Upgrade").GetComponent<Upgrade>();
        InitializeButtons();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (enoughMoney)
            upgradeButton.interactable = true;
        else
        {
            upgradeButton.interactable = false;
        }
    }

    public void Visible(ground g)
    {
        gameObject.SetActive(true);
        currentGround = g;
    }

    void InitializeButtons()
    {
        resumeButton = GameObject.Find("ResumeU").gameObject.GetComponent<Button>();
        resumeButton.onClick.AddListener(Resume);
        sellButton = GameObject.Find("Sell").gameObject.GetComponent<Button>();
        sellButton.onClick.AddListener(Sell);
        upgradeButton = GameObject.Find("Upgrade").gameObject.GetComponent<Button>();
        upgradeButton.onClick.AddListener(UUpgrade);
    }

    void Resume()
    {
        gameObject.SetActive(false);
        game.theGame.EnableEverything();
    }

    void Sell()
    {
        currentGround.SellTower();
        currentGround.SetHasTower();
        gameObject.SetActive(false);
        game.theGame.EnableEverything();
    }

    void UUpgrade()
    {

    }
}
