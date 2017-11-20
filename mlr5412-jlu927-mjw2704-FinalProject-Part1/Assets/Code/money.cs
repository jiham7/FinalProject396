using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class money : MonoBehaviour
{

    public int currentMoney;
    private Text moneyText;

	// Use this for initialization
	void Start ()
	{
	    moneyText = GetComponent<Text>();
	    currentMoney = 100;
        UpdateMoney();
	}

    void UpdateMoney()
    {
        moneyText.text = "Money: " + string.Format("{0}", currentMoney);
    }

    public int MoneyAmount()
    {
        return currentMoney;
    }

    public void MoreMoney(int i)
    {
        currentMoney = currentMoney + i;
        UpdateMoney();
    }
}
