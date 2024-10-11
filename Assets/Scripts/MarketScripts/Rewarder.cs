using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;
public class Rewarder : MonoBehaviour
{
    public static Rewarder Instance;
    [Header("Balls")]

    [SerializeField] string AppForBalls1 = "AppForBalls1";
    [SerializeField] string AppForBalls2 = "AppForBalls2";

    public int PurchaseForBall_Ball1 = 0;
    public int PurchaseForBall_Ball2 = 0;

    [SerializeField] private GameObject yenText1, yenText2;
    [SerializeField] private MarketScript _marketScript;

    [SerializeField] private Button buyBall8, buyBall9;

    [Header("Dollars")]

    [SerializeField] string AppForDollar1 = "AppForDollar1";
    [SerializeField] string AppForDollar2 = "AppForDollar2";
    [SerializeField] string AppForDollar3 = "AppForDollar3";

    public int PurchaseForDollar_Dollar1 = 10000;
    public int PurchaseForDollar_Dollar2 = 100000;
    public int PurchaseForDollar_Dollar3 = 1000000;    

    [SerializeField] private TextMeshProUGUI moneyText;

    [Header("Boosters")]

    [SerializeField] string AppForForeverBallsBoost = "AppForForeverBallsBoost";
    [SerializeField] string AppForForeverIncomeBoost = "AppForForeverIncomeBoost";
    [SerializeField] string AppForForeverAutoClickBoost = "AppForForeverAutoClickBoost";

    public int PurchaseForForeverBallsBoost = 0;
    public int PurchaseForForeverIncomeBoost = 0;
    public int PurchaseForForeverAutoClickBoost = 0;

    [SerializeField] private GameObject foreverBallBoostObject;
    [SerializeField] private GameObject foreverIncomeBoostObject;
    [SerializeField] private GameObject foreverAutoClickObject;

    [SerializeField] private BoosterUIScript _boosterUIScript;



    Dictionary<string, int> OperationNameAndReward = new();
    private void Awake()
    {
        OperationNameAndReward.Add(AppForForeverBallsBoost, PurchaseForForeverBallsBoost);
        OperationNameAndReward.Add(AppForForeverIncomeBoost, PurchaseForForeverIncomeBoost);
        OperationNameAndReward.Add(AppForForeverAutoClickBoost, PurchaseForForeverAutoClickBoost);


        OperationNameAndReward.Add(AppForDollar1, PurchaseForDollar_Dollar1);
        OperationNameAndReward.Add(AppForDollar2, PurchaseForDollar_Dollar2);
        OperationNameAndReward.Add(AppForDollar3, PurchaseForDollar_Dollar3);


        OperationNameAndReward.Add(AppForBalls1, PurchaseForBall_Ball1);
        OperationNameAndReward.Add(AppForBalls2, PurchaseForBall_Ball2);
        Instance = this;
    }
    void Start()
    {
        Geekplay.Instance.SubscribeOnPurchase(AppForDollar1, GetDollarPur1);
        Geekplay.Instance.SubscribeOnPurchase(AppForDollar2, GetDollarPur2);
        Geekplay.Instance.SubscribeOnPurchase(AppForDollar3, GetDollarPur3);

        Geekplay.Instance.SubscribeOnPurchase(AppForForeverBallsBoost, GetForeverBallBoost);
        Geekplay.Instance.SubscribeOnPurchase(AppForForeverIncomeBoost, GetForeverIncomeBoost);
        Geekplay.Instance.SubscribeOnPurchase(AppForForeverAutoClickBoost, GetForeverAutoClickBosst);

        Geekplay.Instance.SubscribeOnPurchase(AppForBalls1, GetBall1);
        Geekplay.Instance.SubscribeOnPurchase(AppForBalls2, GetBall2);


    }
    public int GetDiamondCountByName(string Name)
    {
        try
        {
            return OperationNameAndReward[Name];
        }
        catch
        {
            Debug.Log("ÍÅÂÅÐÍÎÅ ÈÌß ÄËß PURCHASE");
            return -1;
        }
    }    

    public void GetDollarPur1()
    {
        Geekplay.Instance.PlayerData.MoneyToAdd += (ulong)PurchaseForDollar_Dollar1;
        moneyText.text = FormatMoney(Geekplay.Instance.PlayerData.MoneyToAdd);
        Geekplay.Instance.Save();

    }
    public void GetDollarPur2()
    {
        Geekplay.Instance.PlayerData.MoneyToAdd += (ulong)PurchaseForDollar_Dollar2;
        moneyText.text = FormatMoney(Geekplay.Instance.PlayerData.MoneyToAdd);
        Geekplay.Instance.Save();
    }
    public void GetDollarPur3()
    {
        Geekplay.Instance.PlayerData.MoneyToAdd += (ulong)PurchaseForDollar_Dollar3;
        moneyText.text = FormatMoney(Geekplay.Instance.PlayerData.MoneyToAdd);
        Geekplay.Instance.Save();
    }


    public void GetForeverBallBoost()
    {
        Geekplay.Instance.PlayerData.ForeverBallsBoost = true;
        Geekplay.Instance.Save();
        foreverBallBoostObject.SetActive(false);
        _boosterUIScript.doubleBallButton.interactable = false;
        _boosterUIScript.StartForeverBallsBoostCorutine();
    }

    public void GetForeverIncomeBoost()
    {
        Geekplay.Instance.PlayerData.ForeverIncomeBoost = true;
        Geekplay.Instance.Save();
        foreverIncomeBoostObject.SetActive(false);
        _boosterUIScript.incomeButton.interactable = false;
        _boosterUIScript.StartForeverIncomeBoostCorutine();
    }

    public void GetForeverAutoClickBosst()
    {
        Geekplay.Instance.PlayerData.ForeverAutoClickBoost = true;
        Geekplay.Instance.Save();
        foreverAutoClickObject.SetActive(false);
        _boosterUIScript.autoClickButton.interactable = false;
        _boosterUIScript.StartForeverAutoClickBoostCorutine();
    }

    public void GetBall1()
    {
        if (!Geekplay.Instance.PlayerData.BallsBought[7])
        {
            yenText1.SetActive(false);
            Geekplay.Instance.PlayerData.BallsBought[7] = true;
            Geekplay.Instance.Save();
            buyBall8.onClick.RemoveAllListeners();
            buyBall8.onClick.AddListener(() => _marketScript.PressedBall8(7));
        }
        else
        {
            buyBall8.onClick.RemoveAllListeners();
            buyBall8.onClick.AddListener(() => _marketScript.PressedBall8(7));
        }
    }
    public void GetBall2()
    {
        if (!Geekplay.Instance.PlayerData.BallsBought[8])
        {
            yenText2.SetActive(false);
            Geekplay.Instance.PlayerData.BallsBought[8] = true;
            Geekplay.Instance.Save();
            buyBall9.onClick.RemoveAllListeners();
            buyBall9.onClick.AddListener(() => _marketScript.PressedBall9(8));
        }
        else
        {
            buyBall9.onClick.RemoveAllListeners();
            buyBall9.onClick.AddListener(() => _marketScript.PressedBall9(8));
        }
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

        return $"{value:0.#}{suffixes[suffixIndex]}";
    }
}