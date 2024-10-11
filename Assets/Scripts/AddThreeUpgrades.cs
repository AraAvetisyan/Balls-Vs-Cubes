using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddThreeUpgrades : MonoBehaviour
{
    [SerializeField] private GameObject[] multyplayerButtonObjects;
    [SerializeField] private Button[] multyplayerButtons;
    [SerializeField] private int randMax, randMin;
    private float randStart;
    private int randButton;
    private Coroutine buttonShowCorutine;
    private Coroutine buttonUnshowCorutine;

    [SerializeField] private TextMeshProUGUI healthLevel, healthPriceText;
    [SerializeField] private ulong healthPrice;

    [SerializeField] private TextMeshProUGUI powerLevel, powerPriceText;
    [SerializeField] private ulong powerPrice;

    [SerializeField] private TextMeshProUGUI incomeLevel, incomePriceText;
    [SerializeField] private ulong incomePrice;

    [SerializeField] private TextMeshProUGUI countLevel, countPriceText;
    [SerializeField] private ulong countPrice;
    void Start()
    {
        StartShowCorutine();
    }
    public void StartShowCorutine()
    {
        buttonShowCorutine = StartCoroutine(ShowButton());
    }
    public void StopShowCorutine()
    {
        if(buttonShowCorutine != null)
        {
            StopCoroutine(buttonShowCorutine);
            buttonShowCorutine = null;
        }
        StartUnshowCorutine();
    }
    public void StartUnshowCorutine()
    {
        buttonUnshowCorutine = StartCoroutine(UnshowButton());
    }
    public void StopUnshowCorutine()
    {
        if (buttonUnshowCorutine != null)
        {
            StopCoroutine(buttonUnshowCorutine);
            buttonUnshowCorutine = null;
        }
        StartShowCorutine();
    }
    public IEnumerator ShowButton()
    {
        randStart = Random.Range(randMax, randMin);
        float duration = randStart;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }
        if (Geekplay.Instance.PlayerData.MaxSpawnCount < 30)
        {
            randButton = Random.Range(0, multyplayerButtonObjects.Length);
        }
        if (Geekplay.Instance.PlayerData.MaxSpawnCount >= 30)
        {
            Geekplay.Instance.PlayerData.MaxSpawnCount = 30;
            randButton = Random.Range(0, multyplayerButtonObjects.Length - 1);
        }
        for (int i = 0; i < multyplayerButtonObjects.Length; i++)
        {
            multyplayerButtonObjects[i].SetActive(false);
        }
        if (!multyplayerButtons[randButton].interactable)
        {
            multyplayerButtonObjects[randButton].SetActive(true);
        }
        StopShowCorutine();
    }
    public IEnumerator UnshowButton()
    {
        float duration = 10;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }
        for (int i = 0; i < multyplayerButtonObjects.Length; i++)
        {
            multyplayerButtonObjects[i].SetActive(false);
        }
        StopUnshowCorutine();
    }


    public void HealthMultyplayer()
    {
        Geekplay.Instance.ShowRewardedAd("HealthMultyplayer");        
    }
    public void HealthReward()
    {
        healthPrice = (ulong)(Mathf.FloorToInt(Geekplay.Instance.PlayerData.HealthPrice));
        for (int i = 0; i < 3; i++)
        {
            Geekplay.Instance.PlayerData.BallHealth += 1;
            // healthLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.BallHealth.ToString();
            if (Geekplay.Instance.language == "en")
                healthLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.BallHealth.ToString();
            else if (Geekplay.Instance.language == "ru")
                healthLevel.text = "УРОВЕНЬ " + Geekplay.Instance.PlayerData.BallHealth.ToString();
            else if (Geekplay.Instance.language == "tr")
                healthLevel.text = "SEVİYE " + Geekplay.Instance.PlayerData.BallHealth.ToString();
            else if (Geekplay.Instance.language == "pr")
                healthLevel.text = "NÍVEL " + Geekplay.Instance.PlayerData.BallHealth.ToString();
            else if (Geekplay.Instance.language == "gr")
                healthLevel.text = "NIVEAU " + Geekplay.Instance.PlayerData.BallHealth.ToString();
            else if (Geekplay.Instance.language == "ar")
                healthLevel.text = "المستوى " + Geekplay.Instance.PlayerData.BallHealth.ToString();
            Geekplay.Instance.PlayerData.HealthPrice = (Geekplay.Instance.PlayerData.HealthPrice + Geekplay.Instance.PlayerData.HealthPrice) + Geekplay.Instance.PlayerData.HealthPrice / 2;
            healthPrice = (ulong)(Geekplay.Instance.PlayerData.HealthPrice);
            healthPriceText.text = "$" + FormatPrice(healthPrice);
            Geekplay.Instance.Save();
        }
        multyplayerButtonObjects[0].SetActive(false);
    }
    public void PowerMultyplayer()
    {
        Geekplay.Instance.ShowRewardedAd("PowerMultyplayer");      
    }
    public void PowerReward()
    {
        powerPrice = (ulong)(Mathf.FloorToInt(Geekplay.Instance.PlayerData.PowerPrice));
        for (int i = 0; i < 3; i++)
        {
            Geekplay.Instance.PlayerData.BallPower += 1;
            // powerLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.BallPower.ToString();
            if (Geekplay.Instance.language == "en")
                powerLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.BallPower.ToString();
            else if (Geekplay.Instance.language == "ru")
                powerLevel.text = "УРОВЕНЬ " + Geekplay.Instance.PlayerData.BallPower.ToString();
            else if (Geekplay.Instance.language == "tr")
                powerLevel.text = "SEVİYE " + Geekplay.Instance.PlayerData.BallPower.ToString();
            else if (Geekplay.Instance.language == "pr")
                powerLevel.text = "NÍVEL " + Geekplay.Instance.PlayerData.BallPower.ToString();
            else if (Geekplay.Instance.language == "gr")
                powerLevel.text = "NIVEAU " + Geekplay.Instance.PlayerData.BallPower.ToString();
            else if (Geekplay.Instance.language == "ar")
                powerLevel.text = "المستوى " + Geekplay.Instance.PlayerData.BallPower.ToString();
            Geekplay.Instance.PlayerData.PowerPrice = (Geekplay.Instance.PlayerData.PowerPrice + Geekplay.Instance.PlayerData.PowerPrice) + Geekplay.Instance.PlayerData.PowerPrice / 2;
            powerPrice = (ulong)(Geekplay.Instance.PlayerData.PowerPrice);
            powerPriceText.text = "$" + FormatPrice(powerPrice);
            Geekplay.Instance.Save();
        }
        multyplayerButtonObjects[1].SetActive(false);
    }
    public void IncomeMultyplater()
    {
        Geekplay.Instance.ShowRewardedAd("IncomeMultyplater");       
    }
    public void IncomeReward()
    {
        incomePrice = (ulong)(Mathf.FloorToInt(Geekplay.Instance.PlayerData.IncomePrice));
        for (int i = 0; i < 3; i++)
        {
            Geekplay.Instance.PlayerData.Income += 1;
            // incomeLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.Income.ToString();
            if (Geekplay.Instance.language == "en")
                incomeLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.Income.ToString();
            else if (Geekplay.Instance.language == "ru")
                incomeLevel.text = "УРОВЕНЬ " + Geekplay.Instance.PlayerData.Income.ToString();
            else if (Geekplay.Instance.language == "tr")
                incomeLevel.text = "SEVİYE " + Geekplay.Instance.PlayerData.Income.ToString();
            else if (Geekplay.Instance.language == "pr")
                incomeLevel.text = "NÍVEL " + Geekplay.Instance.PlayerData.Income.ToString();
            else if (Geekplay.Instance.language == "gr")
                incomeLevel.text = "NIVEAU " + Geekplay.Instance.PlayerData.Income.ToString();
            else if (Geekplay.Instance.language == "ar")
                incomeLevel.text = "المستوى " + Geekplay.Instance.PlayerData.Income.ToString();
            Geekplay.Instance.PlayerData.IncomePrice = (Geekplay.Instance.PlayerData.IncomePrice + Geekplay.Instance.PlayerData.IncomePrice) + Geekplay.Instance.PlayerData.IncomePrice / 2;
            incomePrice = (ulong)(Geekplay.Instance.PlayerData.IncomePrice);
            incomePriceText.text = "$" + FormatPrice(incomePrice);
            Geekplay.Instance.Save();
        }
        multyplayerButtonObjects[2].SetActive(false);
    }

    public void CountMultyplayer()
    {
        Geekplay.Instance.ShowRewardedAd("CountMultyplayer");        
    }
    public void CountReward()
    {
        countPrice = (ulong)(Mathf.FloorToInt(Geekplay.Instance.PlayerData.CountPrice));
        for (int i = 0; i < 3; i++)
        {
            Geekplay.Instance.PlayerData.MaxSpawnCount += 1;
            BallSpawner.Instance.MaximumBallCount += BallSpawner.Instance.BallMaxCountBooster;
            BallSpawner.Instance.SpawnCount += BallSpawner.Instance.BallMaxCountBooster;
            //countLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.MaxSpawnCount.ToString();
            if (Geekplay.Instance.language == "en")
                countLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.MaxSpawnCount.ToString();
            else if (Geekplay.Instance.language == "ru")
                countLevel.text = "УРОВЕНЬ " + Geekplay.Instance.PlayerData.MaxSpawnCount.ToString();
            else if (Geekplay.Instance.language == "tr")
                countLevel.text = "SEVİYE " + Geekplay.Instance.PlayerData.MaxSpawnCount.ToString();
            Geekplay.Instance.PlayerData.CountPrice = Geekplay.Instance.PlayerData.CountPrice + Geekplay.Instance.PlayerData.CountPrice + Geekplay.Instance.PlayerData.CountPrice;
            countPrice = (ulong)(Geekplay.Instance.PlayerData.CountPrice);
            countPriceText.text = "$" + FormatPrice(countPrice);
            Geekplay.Instance.Save();
        }
        multyplayerButtonObjects[3].SetActive(false);
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
