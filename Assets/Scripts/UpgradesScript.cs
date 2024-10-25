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

        yield return new WaitForEndOfFrame();
        Debug.Log("upgrades wait 1");

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
        Debug.Log("upgrades wait 2");
        healthPrice = (ulong)(Mathf.FloorToInt(Geekplay.Instance.PlayerData.HealthPrice));
        powerPrice = (ulong)(Mathf.FloorToInt(Geekplay.Instance.PlayerData.PowerPrice));
        incomePrice = (ulong)(Mathf.FloorToInt(Geekplay.Instance.PlayerData.IncomePrice));
        countPrice = (ulong)(Mathf.FloorToInt(Geekplay.Instance.PlayerData.CountPrice));
        if (Geekplay.Instance.language == "en")
        {
            healthLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.BallHealth.ToString();
            powerLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.BallPower.ToString();
            incomeLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.Income.ToString();
            countLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.MaxSpawnCount.ToString();
        }
        else if (Geekplay.Instance.language == "ru")
        {
            healthLevel.text = "УРОВЕНЬ " + Geekplay.Instance.PlayerData.BallHealth.ToString();
            powerLevel.text = "УРОВЕНЬ " + Geekplay.Instance.PlayerData.BallPower.ToString();
            incomeLevel.text = "УРОВЕНЬ " + Geekplay.Instance.PlayerData.Income.ToString();
            countLevel.text = "УРОВЕНЬ " + Geekplay.Instance.PlayerData.MaxSpawnCount.ToString();
        }
        else if (Geekplay.Instance.language == "tr")
        {
            healthLevel.text = "SEVİYE " + Geekplay.Instance.PlayerData.BallHealth.ToString();
            powerLevel.text = "SEVİYE " + Geekplay.Instance.PlayerData.BallPower.ToString();
            incomeLevel.text = "SEVİYE " + Geekplay.Instance.PlayerData.Income.ToString();
            countLevel.text = "SEVİYE " + Geekplay.Instance.PlayerData.MaxSpawnCount.ToString();
        }
        else if (Geekplay.Instance.language == "es")
        {
            healthLevel.text = "NIVEL " + Geekplay.Instance.PlayerData.BallHealth.ToString();
            powerLevel.text = "NIVEL " + Geekplay.Instance.PlayerData.BallPower.ToString();
            incomeLevel.text = "NIVEL " + Geekplay.Instance.PlayerData.Income.ToString();
            countLevel.text = "NIVEL " + Geekplay.Instance.PlayerData.MaxSpawnCount.ToString();
        }
        else if (Geekplay.Instance.language == "de")
        {
            healthLevel.text = "NIVEAU " + Geekplay.Instance.PlayerData.BallHealth.ToString();
            powerLevel.text = "NIVEAU " + Geekplay.Instance.PlayerData.BallPower.ToString();
            incomeLevel.text = "NIVEAU " + Geekplay.Instance.PlayerData.Income.ToString();
            countLevel.text = "NIVEAU " + Geekplay.Instance.PlayerData.MaxSpawnCount.ToString();
        }
        else if (Geekplay.Instance.language == "ar")
        {
            healthLevel.text = "المستوى " + Geekplay.Instance.PlayerData.BallHealth.ToString();
            powerLevel.text = "المستوى " + Geekplay.Instance.PlayerData.BallPower.ToString();
            incomeLevel.text = "المستوى " + Geekplay.Instance.PlayerData.Income.ToString();
            countLevel.text = "المستوى " + Geekplay.Instance.PlayerData.MaxSpawnCount.ToString();
        }
        healthPriceText.text = "$" + FormatPrice(healthPrice);
        powerPriceText.text = "$" + FormatPrice(powerPrice);
        incomePriceText.text = "$" + FormatPrice(incomePrice);
        countPriceText.text = "$" + FormatPrice(countPrice);

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
            if(Geekplay.Instance.language == "en")
                healthPriceText.text = "INFINITELY";
            else if (Geekplay.Instance.language == "ru")
                healthPriceText.text = "БЕСКОНЕЧНО";
            else if (Geekplay.Instance.language == "tr")
                healthPriceText.text = "SONSUZ";
            else if (Geekplay.Instance.language == "es")
                healthPriceText.text = "INFINITO";
            else if (Geekplay.Instance.language == "de")
                healthPriceText.text = "INFINITELY";
            else if (Geekplay.Instance.language == "ar")
                healthPriceText.text = "غير محدود";
        }
        if (Geekplay.Instance.PlayerData.BallPower >= 46)
        {
            if (Geekplay.Instance.language == "en")
                powerPriceText.text = "INFINITELY";
            else if (Geekplay.Instance.language == "ru")
                powerPriceText.text = "БЕСКОНЕЧНО";
            else if (Geekplay.Instance.language == "tr")
                powerPriceText.text = "SONSUZ";
            else if (Geekplay.Instance.language == "es")
                powerPriceText.text = "INFINITO";
            else if (Geekplay.Instance.language == "de")
                powerPriceText.text = "INFINITELY";
            else if (Geekplay.Instance.language == "ar")
                powerPriceText.text = "غير محدود";
        }
        if (Geekplay.Instance.PlayerData.Income >= 46)
        {
            if (Geekplay.Instance.language == "en")
                incomePriceText.text = "INFINITELY";
            else if (Geekplay.Instance.language == "ru")
                incomePriceText.text = "БЕСКОНЕЧНО";
            else if (Geekplay.Instance.language == "tr")
                incomePriceText.text = "SONSUZ";
            else if (Geekplay.Instance.language == "es")
                incomePriceText.text = "INFINITO";
            else if (Geekplay.Instance.language == "de")
                incomePriceText.text = "INFINITELY";
            else if (Geekplay.Instance.language == "ar")
                incomePriceText.text = "غير محدود";
        }
        if (Geekplay.Instance.PlayerData.MaxSpawnCount >= 30)
        {
            countButton.interactable = false;
            Geekplay.Instance.PlayerData.MaxSpawnCount = 30;
            if (Geekplay.Instance.language == "en")
                countPriceText.text = "MAX.";
            else if (Geekplay.Instance.language == "ru")
                countPriceText.text = "МАКС.";
            else if (Geekplay.Instance.language == "tr")
                countPriceText.text = "MAX.";
            else if (Geekplay.Instance.language == "es")
                countPriceText.text = "MAX.";
            else if (Geekplay.Instance.language == "de")
                countPriceText.text = "MAX.";
            else if (Geekplay.Instance.language == "ar")
                countPriceText.text = "ماكس";
        }
    }

    public void PressedBallHealth()
    {
        Geekplay.Instance.PlayerData.MoneyToAdd =( Geekplay.Instance.PlayerData.MoneyToAdd - (ulong)(Mathf.FloorToInt(Geekplay.Instance.PlayerData.HealthPrice)));
        Geekplay.Instance.PlayerData.BallHealth += 1;
        if(Geekplay.Instance.language == "en")
            healthLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.BallHealth.ToString();
        else if(Geekplay.Instance.language == "ru")
            healthLevel.text = "УРОВЕНЬ " + Geekplay.Instance.PlayerData.BallHealth.ToString();
        else if(Geekplay.Instance.language == "tr")
            healthLevel.text = "SEVİYE " + Geekplay.Instance.PlayerData.BallHealth.ToString();
        else if (Geekplay.Instance.language == "es")
            healthLevel.text = "NIVEL " + Geekplay.Instance.PlayerData.BallHealth.ToString();
        else if (Geekplay.Instance.language == "de")
            healthLevel.text = "NIVEAU " + Geekplay.Instance.PlayerData.BallHealth.ToString();
        else if (Geekplay.Instance.language == "ar")
            healthLevel.text = "المستوى " + Geekplay.Instance.PlayerData.BallHealth.ToString();
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
        if (Geekplay.Instance.language == "en")
            powerLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.BallPower.ToString();
        else if (Geekplay.Instance.language == "ru")
            powerLevel.text = "УРОВЕНЬ " + Geekplay.Instance.PlayerData.BallPower.ToString();
        else if (Geekplay.Instance.language == "tr")
            powerLevel.text = "SEVİYE " + Geekplay.Instance.PlayerData.BallPower.ToString();
        else if (Geekplay.Instance.language == "es")
            powerLevel.text = "NIVEL " + Geekplay.Instance.PlayerData.BallPower.ToString();
        else if (Geekplay.Instance.language == "de")
            powerLevel.text = "NIVEAU " + Geekplay.Instance.PlayerData.BallPower.ToString();
        else if (Geekplay.Instance.language == "ar")
            powerLevel.text = "المستوى " + Geekplay.Instance.PlayerData.BallPower.ToString();
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
        if (Geekplay.Instance.language == "en")
            incomeLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.Income.ToString();
        else if (Geekplay.Instance.language == "ru")
            incomeLevel.text = "УРОВЕНЬ " + Geekplay.Instance.PlayerData.Income.ToString();
        else if (Geekplay.Instance.language == "tr")
            incomeLevel.text = "SEVİYE " + Geekplay.Instance.PlayerData.Income.ToString();
        else if (Geekplay.Instance.language == "es")
            incomeLevel.text = "NIVEL " + Geekplay.Instance.PlayerData.Income.ToString();
        else if (Geekplay.Instance.language == "de")
            incomeLevel.text = "NIVEAU " + Geekplay.Instance.PlayerData.Income.ToString();
        else if (Geekplay.Instance.language == "ar")
            incomeLevel.text = "المستوى " + Geekplay.Instance.PlayerData.Income.ToString();
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
        if (Geekplay.Instance.language == "en")
            countLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.MaxSpawnCount.ToString();
        else if (Geekplay.Instance.language == "ru")
            countLevel.text = "УРОВЕНЬ " + Geekplay.Instance.PlayerData.MaxSpawnCount.ToString();
        else if (Geekplay.Instance.language == "tr")
            countLevel.text = "SEVİYE " + Geekplay.Instance.PlayerData.MaxSpawnCount.ToString();
        else if (Geekplay.Instance.language == "es")
            countLevel.text = "NIVEL " + Geekplay.Instance.PlayerData.MaxSpawnCount.ToString();
        else if (Geekplay.Instance.language == "de")
            countLevel.text = "NIVEAU " + Geekplay.Instance.PlayerData.MaxSpawnCount.ToString();
        else if (Geekplay.Instance.language == "ar")
            countLevel.text = "المستوى " + Geekplay.Instance.PlayerData.MaxSpawnCount.ToString();
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
