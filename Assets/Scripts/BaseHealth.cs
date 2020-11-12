using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] int baseHealth = 10;
    Text healthText;
    private void Start()
    {
        healthText = GetComponent<Text>();
        UpdateHealthText();
    }

    public void AddHealth(int heal)
    {
        baseHealth += heal;
        UpdateHealthText();
    }

    public void DealtDamage(int damage = 1)
    {
        baseHealth -= damage;
        UpdateHealthText();
        if (baseHealth <=0)
        {
            FindObjectOfType<LevelController>().BaseIsDestroyed();
        }
    }

    public void UpdateHealthText() => healthText.text = baseHealth.ToString();
}
