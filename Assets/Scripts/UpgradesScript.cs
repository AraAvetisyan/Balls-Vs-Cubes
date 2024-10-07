using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthLevel;
    [SerializeField] private TextMeshProUGUI powerLevel;
    [SerializeField] private TextMeshProUGUI incomeLevel;
    [SerializeField] private TextMeshProUGUI countLevel;

    [SerializeField] private TextMeshProUGUI healthPriceText;
    [SerializeField] private TextMeshProUGUI powerPriceText;
    [SerializeField] private TextMeshProUGUI incomePriceText;
    [SerializeField] private TextMeshProUGUI countPriceText;

    private int healthPrice;
    private int powerPrice;
    private int incomePrice;
    private int countPrice;

    [SerializeField] private Button healthButton;
    [SerializeField] private Button powerButton;
    [SerializeField] private Button incomeButton;
    [SerializeField] private Button countButton;

    [SerializeField] private TextMeshProUGUI MoneyText;
    private void Start()
    {
        if(Geekplay.Instance.PlayerData.BallHealth == 0)
        {
            Geekplay.Instance.PlayerData.BallHealth = 1;
            Geekplay.Instance.Save();
        }

        if(Geekplay.Instance.PlayerData.HealthPrice == 0)
        {
            Geekplay.Instance.PlayerData.HealthPrice = 10;
            Geekplay.Instance.Save();
        }
        if(Geekplay.Instance.PlayerData.PowerPrice == 0)
        {
            Geekplay.Instance.PlayerData.PowerPrice = 20;
            Geekplay.Instance.Save();
        }
        if(Geekplay.Instance.PlayerData.IncomePrice == 0)
        {
            Geekplay.Instance.PlayerData.IncomePrice = 30;
            Geekplay.Instance.Save();
        }
        if(Geekplay.Instance.PlayerData.CountPrice == 0)
        {
            Geekplay.Instance.PlayerData.CountPrice = 100;
            Geekplay.Instance.Save();
        }
        healthPrice = Mathf.FloorToInt(Geekplay.Instance.PlayerData.HealthPrice);
        powerPrice = Mathf.FloorToInt(Geekplay.Instance.PlayerData.PowerPrice);
        incomePrice = Mathf.FloorToInt(Geekplay.Instance.PlayerData.IncomePrice);
        countPrice = Mathf.FloorToInt(Geekplay.Instance.PlayerData.CountPrice);
        StartCoroutine(WaitFrame());
    }
    private void Update()
    {
        if(Geekplay.Instance.PlayerData.MoneyToAdd >= Geekplay.Instance.PlayerData.HealthPrice)
        {
            healthButton.interactable = true;
        }
        else
        {
            healthButton.interactable = false;
        }
        if(Geekplay.Instance.PlayerData.MoneyToAdd >= Geekplay.Instance.PlayerData.PowerPrice)
        {
            powerButton.interactable = true;
        }
        else
        {
            powerButton.interactable = false;
        }
        if(Geekplay.Instance.PlayerData.MoneyToAdd >= Geekplay.Instance.PlayerData.IncomePrice)
        {
            incomeButton.interactable = true;
        }
        else
        {
            incomeButton.interactable = false;
        }
        if(Geekplay.Instance.PlayerData.MoneyToAdd >= Geekplay.Instance.PlayerData.CountPrice)
        {
            countButton.interactable = true;
        }
        else
        {
            countButton.interactable = false;
        }
    }
    public IEnumerator WaitFrame()
    {
        yield return new WaitForFixedUpdate();
        healthLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.BallHealth.ToString();
        powerLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.BallPower.ToString();
        incomeLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.Income.ToString();
        countLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.MaxSpawnCount.ToString();

        healthPriceText.text = "$" + FormatPrice(healthPrice);
        powerPriceText.text = "$" + FormatPrice(powerPrice);
        incomePriceText.text = "$" + FormatPrice(incomePrice);
        countPriceText.text = "$" + FormatPrice(countPrice);

    }

    public void PressedBallHealth()
    {
        Geekplay.Instance.PlayerData.MoneyToAdd = Geekplay.Instance.PlayerData.MoneyToAdd - Mathf.FloorToInt(Geekplay.Instance.PlayerData.HealthPrice);
        Geekplay.Instance.PlayerData.BallHealth += 1;
        healthLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.BallHealth.ToString();
        Geekplay.Instance.PlayerData.HealthPrice = (Geekplay.Instance.PlayerData.HealthPrice + Geekplay.Instance.PlayerData.HealthPrice) + Geekplay.Instance.PlayerData.HealthPrice / 2;
        healthPrice = Mathf.FloorToInt(Geekplay.Instance.PlayerData.HealthPrice);
        healthPriceText.text = "$" + FormatPrice(healthPrice);
        Geekplay.Instance.Save();
        MoneyText.text = "$" + FormatPrice(Geekplay.Instance.PlayerData.MoneyToAdd);
    }


    public void PressedBallPower()
    {
        Geekplay.Instance.PlayerData.MoneyToAdd = Geekplay.Instance.PlayerData.MoneyToAdd - Mathf.FloorToInt(Geekplay.Instance.PlayerData.PowerPrice);
        Geekplay.Instance.PlayerData.BallPower += 1;
        powerLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.BallPower.ToString();
        Geekplay.Instance.PlayerData.PowerPrice = (Geekplay.Instance.PlayerData.PowerPrice + Geekplay.Instance.PlayerData.PowerPrice) + Geekplay.Instance.PlayerData.PowerPrice / 2;
        powerPrice = Mathf.FloorToInt(Geekplay.Instance.PlayerData.PowerPrice);
        powerPriceText.text = "$" + FormatPrice(powerPrice);
        Geekplay.Instance.Save();
        MoneyText.text = "$" + FormatPrice(Geekplay.Instance.PlayerData.MoneyToAdd);
    }


    public void PressedIncome()
    {
        Geekplay.Instance.PlayerData.MoneyToAdd = Geekplay.Instance.PlayerData.MoneyToAdd - Mathf.FloorToInt(Geekplay.Instance.PlayerData.IncomePrice);
        Geekplay.Instance.PlayerData.Income += 1;
        incomeLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.Income.ToString();
        Geekplay.Instance.PlayerData.IncomePrice = (Geekplay.Instance.PlayerData.IncomePrice + Geekplay.Instance.PlayerData.IncomePrice) + Geekplay.Instance.PlayerData.IncomePrice / 2;
        incomePrice = Mathf.CeilToInt(Geekplay.Instance.PlayerData.IncomePrice);
        incomePriceText.text = "$" + FormatPrice(incomePrice);
        Geekplay.Instance.Save();
        MoneyText.text = "$" + FormatPrice(Geekplay.Instance.PlayerData.MoneyToAdd);
    }


    public void PressedBallCount()
    {
        Geekplay.Instance.PlayerData.MoneyToAdd = Geekplay.Instance.PlayerData.MoneyToAdd - Mathf.FloorToInt(Geekplay.Instance.PlayerData.CountPrice);
        Geekplay.Instance.PlayerData.MaxSpawnCount += 1;
        BallSpawner.Instance.MaximumBallCount += BallSpawner.Instance.BallMaxCountBooster;
        BallSpawner.Instance.SpawnCount += BallSpawner.Instance.BallMaxCountBooster;
        countLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.MaxSpawnCount.ToString();
        Geekplay.Instance.PlayerData.CountPrice = Geekplay.Instance.PlayerData.CountPrice + Geekplay.Instance.PlayerData.CountPrice + Geekplay.Instance.PlayerData.CountPrice;
        countPrice = Mathf.CeilToInt(Geekplay.Instance.PlayerData.CountPrice);
        countPriceText.text = "$" + FormatPrice(countPrice);
        Geekplay.Instance.Save();
        MoneyText.text = "$" + FormatPrice(Geekplay.Instance.PlayerData.MoneyToAdd);
    }
    string FormatPrice(double value)
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

        return $"{value:0.#}{suffixes[suffixIndex]}";
    }
}
