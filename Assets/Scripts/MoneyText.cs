using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MoneyText : MonoBehaviour
{
    int money = 300;
    Text moneyText;
    int income;
    // Start is called before the first frame update
    void Start()
    {
        AdjustDifficulty();
        moneyText = GetComponent<Text>();
        UpdateText();
        income = 0;
    }


    public void AddIncome(int inc)
    {
        income += inc;
    }

    public void DecreaseIncome(int inc)
    {
        income -= inc;
    }

    private void AdjustDifficulty() => money += 40 * Convert.ToInt32(PlayerPrefsController.MasterDifficulty);

    private void UpdateText() => moneyText.text = money.ToString() + " +" + income.ToString();

    public void AddMoney(int income)
    {
        money += income;
        UpdateText();
    }

    public bool IsEnoughMoney(int cost) => money >= cost;
    public void SpendMoney(int payment)
    {
        
            money -= payment;
            UpdateText();
        
    }
}
