using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int Coins { get; set; }

    private int ClickValue { get; set; }

    private int ClickUpgradeValue { get; set; }

    private int AutoClickValue { get; set; }

    private int AutoUpgradeValue { get; set; }

    public bool Quiry { get; set; }

    public bool AutoClicking { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Coins = 0;
        ClickValue = 1;
        ClickUpgradeValue = 5;
        AutoClickValue = 0;
        AutoUpgradeValue = 100;

        Quiry = false;
        AutoClicking = false;
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            foreach (var gameObject in GameObject.FindGameObjectsWithTag("CoinDisplay"))
            {
                gameObject.GetComponent<TMP_Text>().SetText("Coins: " + Coins);
            }
            GameObject.Find("ClickUpText").GetComponent<TMP_Text>().SetText("+1 Coin Per Click: " + ClickUpgradeValue);
            GameObject.Find("AutoUpText").GetComponent<TMP_Text>().SetText("+1 Auto Click: " + AutoUpgradeValue);
        }
        catch
        {}
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
            Coins -= ClickUpgradeValue;
            ClickUpgradeValue = (int)(ClickUpgradeValue * 1.5f);

            Quiry = true;
        }
    }

    public void OnAutoClick()
    {
        Coins += AutoClickValue;

        if (AutoClickValue > 0) Quiry = true;
    }

    public void OnUpgradeAuto()
    {
        if (Coins >= AutoUpgradeValue)
        {
            AutoClickValue += 1;
            Coins -= AutoUpgradeValue;
            AutoUpgradeValue = (int)(AutoUpgradeValue * 1.5f);

            Quiry = true;
        }
    }
}
