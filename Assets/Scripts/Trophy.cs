using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : MonoBehaviour
{
    public MoneyText moneyText;
    public int income;
    private void Start()
    {
        moneyText = FindObjectOfType<MoneyText>();
        moneyText.AddIncome(income);
    }

    public void AddMoney(int income) => moneyText.AddMoney(income);
    private void OnDestroy() => moneyText.DecreaseIncome(income);
}
