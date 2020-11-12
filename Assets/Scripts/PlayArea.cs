using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayArea : MonoBehaviour
{
    Defender selectedDefender;
    MoneyText moneyText;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";

    public Action<Vector2> NotEnoughStars;

    private void Start()
    {
        moneyText = FindObjectOfType<MoneyText>();
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown() => AttemptToSpawn();

    private Vector2 GetSquareClicked()
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        return worldPos;


    }

    Vector2 SnapToGrid(Vector2 whatToSnap) => new Vector2(Mathf.RoundToInt(whatToSnap.x), Mathf.RoundToInt(whatToSnap.y));

    void AttemptToSpawn()
    {
        if (moneyText.IsEnoughMoney(selectedDefender.GetCost()))
        {
            Spawn();
            moneyText.SpendMoney(selectedDefender.GetCost());
        }
     
    }
    void Spawn()
    {
        Vector2 position = SnapToGrid(GetSquareClicked());
        Defender defender = Instantiate(selectedDefender, position, Quaternion.identity) as Defender;
        defender.transform.parent = defenderParent.transform;
    }

    public void SelectDefender(Defender defenderToSelect) => selectedDefender = defenderToSelect;


    public Defender SelectedDefender() => selectedDefender;
}
