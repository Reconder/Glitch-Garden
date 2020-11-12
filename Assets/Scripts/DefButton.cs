using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DefButton : MonoBehaviour
{
    // Start is called before the first frame update
    PlayArea playArea;
    [SerializeField] Defender defenderType;
    SpriteRenderer sprite;

    public UnityEvent OnButtonPressed;

    private void Start()
    {
        playArea = FindObjectOfType<PlayArea>();
        sprite = GetComponent<SpriteRenderer>();
        LabelButtonWithCost();

    }

    private void LabelButtonWithCost()
    {
        Text costText = GetComponentInChildren<Text>();
        if (costText)
        {
            costText.text = defenderType.GetCost().ToString();
        }
    }

    private void OnMouseDown()
    {
        OnButtonPressed?.Invoke();

        playArea.SelectDefender(defenderType);
        sprite.color = Color.white;
    }

    public void ButtonPressed() => sprite.color = new Color32(118, 118, 118, 255);
}
