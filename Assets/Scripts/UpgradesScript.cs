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

    [SerializeField] private ulong healthPrice;
    [SerializeField] private ulong powerPrice;
    [SerializeField] private ulong incomePrice;
    [SerializeField] private ulong countPrice;

    [SerializeField] private Button healthButton;
    [SerializeField] private Button powerButton;
    [SerializeField] private Button incomeButton;
    [SerializeField] private Button countButton;

    [SerializeField] private TextMeshProUGUI MoneyText;
    private void Start()
    {
        StartCoroutine(WaitAFrameForUpgrates());
        
    }
    public IEnumerator WaitAFrameForUpgrates()
    {
        {
            if (Geekplay.Instance.PlayerData.BallHealth == 0)
            {
                Geekplay.Instance.PlayerData.BallHealth = 1;
            }
            if (Geekplay.Instance.PlayerData.HealthPrice == 0)
            {
                Geekplay.Instance.PlayerData.HealthPrice = 10;
            }
            if (Geekplay.Instance.PlayerData.BallPower == 0)
            {
                Geekplay.Instance.PlayerData.BallPower = 1;
            }
            if (Geekplay.Instance.PlayerData.PowerPrice == 0)
            {
                Geekplay.Instance.PlayerData.PowerPrice = 20;
            }
            if (Geekplay.Instance.PlayerData.IncomePrice == 0)
            {
                Geekplay.Instance.PlayerData.IncomePrice = 30;
            }
            if (Geekplay.Instance.PlayerData.CountPrice == 0)
            {
                Geekplay.Instance.PlayerData.CountPrice = 100;
            }
            Geekplay.Instance.Save();
            yield return new WaitForEndOfFrame();
            healthPrice = (ulong)(Mathf.FloorToInt(Geekplay.Instance.PlayerData.HealthPrice));
            powerPrice = (ulong)(Mathf.FloorToInt(Geekplay.Instance.PlayerData.PowerPrice));
            incomePrice = (ulong)(Mathf.FloorToInt(Geekplay.Instance.PlayerData.IncomePrice));
            countPrice = (ulong)(Mathf.FloorToInt(Geekplay.Instance.PlayerData.CountPrice));

            healthLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.BallHealth.ToString();
            powerLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.BallPower.ToString();
            incomeLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.Income.ToString();
            countLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.MaxSpawnCount.ToString();

            healthPriceText.text = "$" + FormatPrice(healthPrice);
            powerPriceText.text = "$" + FormatPrice(powerPrice);
            incomePriceText.text = "$" + FormatPrice(incomePrice);
            countPriceText.text = "$" + FormatPrice(countPrice);
        }
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
            if(Geekplay.Instance.PlayerData.MaxSpawnCount < 30)
            {
                countButton.interactable = true;
            }
            
        }
        else
        {
            countButton.interactable = false;
        }
        if (Geekplay.Instance.PlayerData.BallHealth >= 46)
        {
            healthPriceText.text = "INFINITELY";
        }
        if (Geekplay.Instance.PlayerData.BallPower >= 46)
        {
            powerPriceText.text = "INFINITELY";
        }
        if (Geekplay.Instance.PlayerData.Income >= 46)
        {
            incomePriceText.text = "INFINITELY";
        }
        if (Geekplay.Instance.PlayerData.MaxSpawnCount >= 30)
        {
            countButton.interactable = false;
            Geekplay.Instance.PlayerData.MaxSpawnCount = 30;
            countPriceText.text = "MAX";
        }
    }

    public void PressedBallHealth()
    {
        Geekplay.Instance.PlayerData.MoneyToAdd =( Geekplay.Instance.PlayerData.MoneyToAdd - (ulong)(Mathf.FloorToInt(Geekplay.Instance.PlayerData.HealthPrice)));
        Geekplay.Instance.PlayerData.BallHealth += 1;
        healthLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.BallHealth.ToString();
        Geekplay.Instance.PlayerData.HealthPrice = (Geekplay.Instance.PlayerData.HealthPrice + Geekplay.Instance.PlayerData.HealthPrice) + Geekplay.Instance.PlayerData.HealthPrice / 2;
        healthPrice = (ulong)(Geekplay.Instance.PlayerData.HealthPrice);
        healthPriceText.text = "$" + FormatPrice(healthPrice);
        Geekplay.Instance.Save();
        MoneyText.text = "$" + FormatPrice(Geekplay.Instance.PlayerData.MoneyToAdd);
    }


    public void PressedBallPower()
    {
        Geekplay.Instance.PlayerData.MoneyToAdd = Geekplay.Instance.PlayerData.MoneyToAdd - (ulong)(Mathf.FloorToInt(Geekplay.Instance.PlayerData.PowerPrice));
        Geekplay.Instance.PlayerData.BallPower += 1;
        powerLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.BallPower.ToString();
        Geekplay.Instance.PlayerData.PowerPrice = (Geekplay.Instance.PlayerData.PowerPrice + Geekplay.Instance.PlayerData.PowerPrice) + Geekplay.Instance.PlayerData.PowerPrice / 2;
        powerPrice = (ulong)(Geekplay.Instance.PlayerData.PowerPrice);
        powerPriceText.text = "$" + FormatPrice(powerPrice);
        Geekplay.Instance.Save();
        MoneyText.text = "$" + FormatPrice(Geekplay.Instance.PlayerData.MoneyToAdd);
    }


    public void PressedIncome()
    {
        Geekplay.Instance.PlayerData.MoneyToAdd = Geekplay.Instance.PlayerData.MoneyToAdd - (ulong)(Mathf.FloorToInt(Geekplay.Instance.PlayerData.IncomePrice));
        Geekplay.Instance.PlayerData.Income += 1;
        incomeLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.Income.ToString();
        Geekplay.Instance.PlayerData.IncomePrice = (Geekplay.Instance.PlayerData.IncomePrice + Geekplay.Instance.PlayerData.IncomePrice) + Geekplay.Instance.PlayerData.IncomePrice / 2;
        incomePrice = (ulong)(Geekplay.Instance.PlayerData.IncomePrice);
        incomePriceText.text = "$" + FormatPrice(incomePrice);
        Geekplay.Instance.Save();
        MoneyText.text = "$" + FormatPrice(Geekplay.Instance.PlayerData.MoneyToAdd);
    }


    public void PressedBallCount()
    {
        Geekplay.Instance.PlayerData.MoneyToAdd = Geekplay.Instance.PlayerData.MoneyToAdd - (ulong)(Mathf.FloorToInt(Geekplay.Instance.PlayerData.CountPrice));
        Geekplay.Instance.PlayerData.MaxSpawnCount += 1;
        BallSpawner.Instance.MaximumBallCount += BallSpawner.Instance.BallMaxCountBooster;
        BallSpawner.Instance.SpawnCount += BallSpawner.Instance.BallMaxCountBooster;
        countLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.MaxSpawnCount.ToString();
        Geekplay.Instance.PlayerData.CountPrice = Geekplay.Instance.PlayerData.CountPrice + Geekplay.Instance.PlayerData.CountPrice + Geekplay.Instance.PlayerData.CountPrice;
        countPrice = (ulong)(Mathf.CeilToInt(Geekplay.Instance.PlayerData.CountPrice));
        countPriceText.text = "$" + FormatPrice(countPrice);
        Geekplay.Instance.Save();
        MoneyText.text = "$" + FormatPrice(Geekplay.Instance.PlayerData.MoneyToAdd);
    }
    string FormatPrice(ulong value)
    {
        if (value < 0)
        {
            return "Invalid value"; // Обрабатываем отрицательные значения
        }

        string[] suffixes = { "", "k", "m", "b", "t", "aa", "ab", "ac", "ad", "ae", "af", "ag", "ah", "ai", "aj", "ak", "al", "am", "an", "ao", "ap", "aq", "ar", "as", "at", "au", "av", "aw", "ax", "ay", "az" };
        int suffixIndex = 0;
        decimal formattedValue = value; // Преобразуем в double для работы с дробной частью

        // Пока значение больше или равно 1000, уменьшаем его и добавляем суффикс
        while (formattedValue >= 1000 && suffixIndex < suffixes.Length - 1)
        {
            formattedValue /= 1000;
            suffixIndex++;
        }

        // Форматируем результат с одной десятичной частью
        return $"{formattedValue:0.#}{suffixes[suffixIndex]}";
    }
}
