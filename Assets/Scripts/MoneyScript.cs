using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI MoneyText;
    public int income;
    [SerializeField] private GameObject passiveIncomePanel;
    [SerializeField] private TextMeshProUGUI passiveText;
    private int passivIncome;

    private void Start()
    {
        if (!Geekplay.Instance.PlayerData.IsNotFirstTime)
        {
            Geekplay.Instance.PlayerData.IsNotFirstTime = true;
        }
        else if (Geekplay.Instance.PlayerData.IsNotFirstTime)
        {
            DateTime lastSaveTime = UtilsForGame.GetDateTime("LastSaveTime", DateTime.UtcNow);
            TimeSpan timePassed = DateTime.UtcNow - lastSaveTime;
            int secondsPassed = (int)timePassed.TotalSeconds;
            secondsPassed = Mathf.Clamp(secondsPassed, 0, 7 * 24 * 60 * 60);
            passivIncome = (((Geekplay.Instance.PlayerData.Income + Geekplay.Instance.PlayerData.RebornCount) * BallSpawner.Instance.IncomeBoost) * secondsPassed) / 10;
            passiveIncomePanel.SetActive(true);
            passiveText.text = "YOU ERND $" + passivIncome;
            Geekplay.Instance.PlayerData.MoneyToAdd += passivIncome;
            MoneyText.text = "$" + FormatMoney(Geekplay.Instance.PlayerData.MoneyToAdd);
        }
        if (Geekplay.Instance.PlayerData.Income == 0)
        {
            Geekplay.Instance.PlayerData.Income = 1;
            Geekplay.Instance.Save();
        }
        MoneyText.text = "$" + FormatMoney(Geekplay.Instance.PlayerData.MoneyToAdd);
    }
    public void AddMoney()
    {
        income = (Geekplay.Instance.PlayerData.Income + Geekplay.Instance.PlayerData.RebornCount) * BallSpawner.Instance.IncomeBoost;
        Geekplay.Instance.PlayerData.MoneyToAdd += income;        
        MoneyText.text = "$" + FormatMoney(Geekplay.Instance.PlayerData.MoneyToAdd);

    }
    private void OnApplicationQuit()
    {
        
        UtilsForGame.SetDateTime("LastSaveTime", DateTime.UtcNow);
        Geekplay.Instance.Save();
    }
    string FormatMoney(double value)
    {
        string[] suffixes = { "", "k", "m", "b", "t", "aa", "ab", "ac", "ad", "ae", "af", "ag", "ah", "ai", "aj", "ak", "al", "am", "an", "ao", "ap", "aq", "ar", "as", "at", "au", "av", "aw", "ax", "ay", "az" };
        int suffixIndex = 0;

        while (value >= 1000 && suffixIndex < suffixes.Length - 1)
        {
            value /= 1000;
            suffixIndex++;
        }

        if (value >= 1000)
        {
            value = 999.99;
        }

        return $"{value:0.##}{suffixes[suffixIndex]}";
    }
}
