using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int Coins { get; set; }

    private int ClickValue { get; set; }

    private int ClickUpgradeValue { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Coins = 0;
        ClickValue = 1;
        ClickUpgradeValue = 5;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var gameObject in GameObject.FindGameObjectsWithTag("CoinDisplay"))
        {
            gameObject.GetComponent<TMP_Text>().SetText("Coins: " + Coins);
        }
    }

    public void OnCoinClick()
    {
        Coins += ClickValue;
    }

    public void OnUpgradeClick()
    {
        if (Coins >= ClickUpgradeValue)
        {
            ClickValue += 1;
            ClickUpgradeValue = (int)(ClickUpgradeValue * 1.5f);
        }
    }
}
