using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddThreeUpgrades : MonoBehaviour
{
    [SerializeField] private GameObject[] multyplayerButtons;
    [SerializeField] private int randMax, randMin;
    private float randStart;
    private int randButton;
    private Coroutine buttonShowCorutine;
    private Coroutine buttonUnshowCorutine;

    [SerializeField] private TextMeshProUGUI healthLevel, healthPriceText;
    [SerializeField] private int healthPrice;

    [SerializeField] private TextMeshProUGUI powerLevel, powerPriceText;
    [SerializeField] private int powerPrice;

    [SerializeField] private TextMeshProUGUI incomeLevel, incomePriceText;
    [SerializeField] private int incomePrice;

    [SerializeField] private TextMeshProUGUI countLevel, countPriceText;
    [SerializeField] private int countPrice;
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
        randButton = Random.Range(0,multyplayerButtons.Length);
        for (int i = 0; i < multyplayerButtons.Length; i++)
        {
            multyplayerButtons[randButton].SetActive(true);
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
        for (int i = 0; i < multyplayerButtons.Length; i++)
        {
            multyplayerButtons[i].SetActive(false);
        }
        StopUnshowCorutine();
    }


    public void HealthMultyplayer()
    {
        healthPrice = Mathf.FloorToInt(Geekplay.Instance.PlayerData.HealthPrice);
        for (int i = 0; i < 3; i++)
        {
            Geekplay.Instance.PlayerData.BallHealth += 1;
            healthLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.BallHealth.ToString();
            Geekplay.Instance.PlayerData.HealthPrice = (Geekplay.Instance.PlayerData.HealthPrice + Geekplay.Instance.PlayerData.HealthPrice) + Geekplay.Instance.PlayerData.HealthPrice / 2;
            healthPrice = Mathf.FloorToInt(Geekplay.Instance.PlayerData.HealthPrice);
            healthPriceText.text = "$" + FormatPrice(healthPrice);
            Geekplay.Instance.Save();
        }
        multyplayerButtons[0].SetActive(false);
    }

    public void PowerMultyplayer()
    {
        powerPrice = Mathf.FloorToInt(Geekplay.Instance.PlayerData.PowerPrice);
        for (int i = 0; i < 3; i++)
        {
            Geekplay.Instance.PlayerData.BallPower += 1;
            powerLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.BallPower.ToString();
            Geekplay.Instance.PlayerData.PowerPrice = (Geekplay.Instance.PlayerData.PowerPrice + Geekplay.Instance.PlayerData.PowerPrice) + Geekplay.Instance.PlayerData.PowerPrice / 2;
            powerPrice = Mathf.FloorToInt(Geekplay.Instance.PlayerData.PowerPrice);
            powerPriceText.text = "$" + FormatPrice(powerPrice);
            Geekplay.Instance.Save();
        }
        multyplayerButtons[1].SetActive(false);
    }

    public void IncomeMultyplater()
    {
        incomePrice = Mathf.FloorToInt(Geekplay.Instance.PlayerData.IncomePrice);
        for (int i = 0; i < 3; i++)
        {
            Geekplay.Instance.PlayerData.Income += 1;
            incomeLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.Income.ToString();
            Geekplay.Instance.PlayerData.IncomePrice = (Geekplay.Instance.PlayerData.IncomePrice + Geekplay.Instance.PlayerData.IncomePrice) + Geekplay.Instance.PlayerData.IncomePrice / 2;
            incomePrice = Mathf.CeilToInt(Geekplay.Instance.PlayerData.IncomePrice);
            incomePriceText.text = "$" + FormatPrice(incomePrice);
            Geekplay.Instance.Save();
        }
        multyplayerButtons[2].SetActive(false);
    }

    public void CountMultyplayer()
    {
        countPrice = Mathf.FloorToInt(Geekplay.Instance.PlayerData.CountPrice);
        for (int i = 0; i < 3; i++)
        {
            Geekplay.Instance.PlayerData.MaxSpawnCount += 1;
            BallSpawner.Instance.MaximumBallCount += BallSpawner.Instance.BallMaxCountBooster;
            BallSpawner.Instance.SpawnCount += BallSpawner.Instance.BallMaxCountBooster;
            countLevel.text = "LEVEL " + Geekplay.Instance.PlayerData.MaxSpawnCount.ToString();
            Geekplay.Instance.PlayerData.CountPrice = Geekplay.Instance.PlayerData.CountPrice + Geekplay.Instance.PlayerData.CountPrice + Geekplay.Instance.PlayerData.CountPrice;
            countPrice = Mathf.CeilToInt(Geekplay.Instance.PlayerData.CountPrice);
            countPriceText.text = "$" + FormatPrice(countPrice);
            Geekplay.Instance.Save();
        }
        multyplayerButtons[3].SetActive(false);
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
