using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MarketScript : MonoBehaviour
{
    [SerializeField] private GameObject dollarsMarker, ballsMarker;
    [SerializeField] private GameObject dollarsPanel, ballsPanel;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private Button dollarsButton, ballsButton;
    [SerializeField] private Button[] ballButtons;
    [SerializeField] private int[] prices;
    [SerializeField] private GameObject[] pricesObjects;
    [SerializeField] private TextMeshProUGUI dollarsText;
    private void Start()
    {
        PressedDollarsButton();
        StartCoroutine(WaitAFrameForMarket());
       
    }
    public IEnumerator WaitAFrameForMarket()
    {
        yield return new WaitForEndOfFrame();
        if(Geekplay.Instance.PlayerData.BallsBought == null)
        {
            Geekplay.Instance.PlayerData.BallsBought = new bool[9];
        }
        if (Geekplay.Instance.PlayerData.BallEnabled == null)
        {
            Geekplay.Instance.PlayerData.BallEnabled = new bool[9];
        }
        for (int i = 0; i < Geekplay.Instance.PlayerData.BallsBought.Length; i++)
        {
            if (Geekplay.Instance.PlayerData.BallsBought[i])
            {
                pricesObjects[i].SetActive(false);
                ballButtons[i].interactable = true;
            }
        }
        
        for (int i = 0; i < prices.Length; i++)
        {
            if (Geekplay.Instance.PlayerData.MoneyToAdd > prices[i])
            {
                ballButtons[i].interactable = true;
            }
            else
            {
                if (!Geekplay.Instance.PlayerData.BallsBought[i])
                {
                    ballButtons[i].interactable = false;
                }
            }
        }
        for (int i = 0; i < Geekplay.Instance.PlayerData.BallEnabled.Length; i++)
        {
            if (Geekplay.Instance.PlayerData.BallEnabled[i])
            {
                BallSpawner.Instance.ColorIndex = i;
                ballButtons[i].interactable = false;
            }
        }
        Geekplay.Instance.Save();
    }
    public void PressedDollarsButton()
    {
        ballsMarker.SetActive(false);
        ballsPanel.SetActive(false);
        dollarsMarker.SetActive(true);
        dollarsPanel.SetActive(true);
        dollarsButton.interactable = false;
        ballsButton.interactable = true;
        titleText.text = "DOLLARS";
    }
    public void PressedBallsButton()
    {
        dollarsMarker.SetActive(false);
        dollarsPanel.SetActive(false);
        ballsMarker.SetActive(true);
        ballsPanel.SetActive(true);
        ballsButton.interactable = false;
        dollarsButton.interactable = true;
        titleText.text = "BALLS";
        
    }

    public void PressedBall1(int index)
    {
        if (!Geekplay.Instance.PlayerData.BallsBought[index])
        {
            if (Geekplay.Instance.PlayerData.MoneyToAdd > prices[index])
            {
                Geekplay.Instance.PlayerData.MoneyToAdd -= prices[index];
                dollarsText.text = FormatPrice(Geekplay.Instance.PlayerData.MoneyToAdd);
              
                Geekplay.Instance.PlayerData.BallsBought[index] = true;
                BallSpawner.Instance.ColorIndex = index;
                for(int i = 0; i < Geekplay.Instance.PlayerData.BallEnabled.Length; i++)
                {
                    Geekplay.Instance.PlayerData.BallEnabled[i] = false;
                }
                Geekplay.Instance.PlayerData.BallEnabled[index] = true;
            }
        }
        else
        {
            BallSpawner.Instance.ColorIndex = index;
            for (int i = 0; i < Geekplay.Instance.PlayerData.BallEnabled.Length; i++)
            {
                Geekplay.Instance.PlayerData.BallEnabled[i] = false;
            }
            Geekplay.Instance.PlayerData.BallEnabled[index] = true;
        }
        StartCoroutine(WaitAFrameForMarket());
    }
    public void PressedBall2(int index)
    {
        if (!Geekplay.Instance.PlayerData.BallsBought[index])
        {
            if (Geekplay.Instance.PlayerData.MoneyToAdd > prices[index])
            {
                Geekplay.Instance.PlayerData.MoneyToAdd -= prices[index];
                dollarsText.text = FormatPrice(Geekplay.Instance.PlayerData.MoneyToAdd);
                Geekplay.Instance.PlayerData.BallsBought[index] = true;
                BallSpawner.Instance.ColorIndex = index;
                for (int i = 0; i < Geekplay.Instance.PlayerData.BallEnabled.Length; i++)
                {
                    Geekplay.Instance.PlayerData.BallEnabled[i] = false;
                }
                Geekplay.Instance.PlayerData.BallEnabled[index] = true;
            }
        }
        else
        {
            BallSpawner.Instance.ColorIndex = index;
            for (int i = 0; i < Geekplay.Instance.PlayerData.BallEnabled.Length; i++)
            {
                Geekplay.Instance.PlayerData.BallEnabled[i] = false;
            }
            Geekplay.Instance.PlayerData.BallEnabled[index] = true;
        }
        StartCoroutine(WaitAFrameForMarket());
    }
    public void PressedBall3(int index)
    {
        if (!Geekplay.Instance.PlayerData.BallsBought[index])
        {
            if (Geekplay.Instance.PlayerData.MoneyToAdd > prices[index])
            {
                Geekplay.Instance.PlayerData.MoneyToAdd -= prices[index];
                dollarsText.text = FormatPrice(Geekplay.Instance.PlayerData.MoneyToAdd);
                Geekplay.Instance.PlayerData.BallsBought[index] = true; 
                BallSpawner.Instance.ColorIndex = index;
                for (int i = 0; i < Geekplay.Instance.PlayerData.BallEnabled.Length; i++)
                {
                    Geekplay.Instance.PlayerData.BallEnabled[i] = false;
                }
                Geekplay.Instance.PlayerData.BallEnabled[index] = true;
            }
        }
        else
        {
            BallSpawner.Instance.ColorIndex = index;
            for (int i = 0; i < Geekplay.Instance.PlayerData.BallEnabled.Length; i++)
            {
                Geekplay.Instance.PlayerData.BallEnabled[i] = false;
            }
            Geekplay.Instance.PlayerData.BallEnabled[index] = true;
        }
        StartCoroutine(WaitAFrameForMarket());
    }
    public void PressedBall4(int index)
    {
        if (!Geekplay.Instance.PlayerData.BallsBought[index])
        {
            if (Geekplay.Instance.PlayerData.MoneyToAdd > prices[index])
            {
                Geekplay.Instance.PlayerData.MoneyToAdd -= prices[index];
                dollarsText.text = FormatPrice(Geekplay.Instance.PlayerData.MoneyToAdd);
                Geekplay.Instance.PlayerData.BallsBought[index] = true;
                BallSpawner.Instance.ColorIndex = index;
                for (int i = 0; i < Geekplay.Instance.PlayerData.BallEnabled.Length; i++)
                {
                    Geekplay.Instance.PlayerData.BallEnabled[i] = false;
                }
                Geekplay.Instance.PlayerData.BallEnabled[index] = true;
            }
        }
        else
        {
            BallSpawner.Instance.ColorIndex = index;
            for (int i = 0; i < Geekplay.Instance.PlayerData.BallEnabled.Length; i++)
            {
                Geekplay.Instance.PlayerData.BallEnabled[i] = false;
            }
            Geekplay.Instance.PlayerData.BallEnabled[index] = true;
        }
        StartCoroutine(WaitAFrameForMarket());
    }
    public void PressedBall5(int index)
    {
        if (!Geekplay.Instance.PlayerData.BallsBought[index])
        {
            if (Geekplay.Instance.PlayerData.MoneyToAdd > prices[index])
            {
                Geekplay.Instance.PlayerData.MoneyToAdd -= prices[index];
                dollarsText.text = FormatPrice(Geekplay.Instance.PlayerData.MoneyToAdd);
                Geekplay.Instance.PlayerData.BallsBought[index] = true;
                BallSpawner.Instance.ColorIndex = index;
                for (int i = 0; i < Geekplay.Instance.PlayerData.BallEnabled.Length; i++)
                {
                    Geekplay.Instance.PlayerData.BallEnabled[i] = false;
                }
                Geekplay.Instance.PlayerData.BallEnabled[index] = true;
            }
        }
        else
        {
            BallSpawner.Instance.ColorIndex = index;
            for (int i = 0; i < Geekplay.Instance.PlayerData.BallEnabled.Length; i++)
            {
                Geekplay.Instance.PlayerData.BallEnabled[i] = false;
            }
            Geekplay.Instance.PlayerData.BallEnabled[index] = true;
        }
        StartCoroutine(WaitAFrameForMarket());
    }
    public void PressedBall6(int index)
    {
        if (!Geekplay.Instance.PlayerData.BallsBought[index])
        {
            Geekplay.Instance.ShowRewardedAd("BallReward1");
        }
        else
        {
            Ball6Reward(index);
        }
    }
    public void PressedBall7(int index)
    {
        if (!Geekplay.Instance.PlayerData.BallsBought[index])
        {
            Geekplay.Instance.ShowRewardedAd("BallReward2");
        }
        else
        {
            Ball7Reward(index);
        }
    }

    public void Ball6Reward(int index)
    {
        BallSpawner.Instance.ColorIndex = index;
        for (int i = 0; i < Geekplay.Instance.PlayerData.BallEnabled.Length; i++)
        {
            Geekplay.Instance.PlayerData.BallEnabled[i] = false;
        }
        Geekplay.Instance.PlayerData.BallEnabled[index] = true;
        Geekplay.Instance.PlayerData.BallsBought[index] = true;
        StartCoroutine(WaitAFrameForMarket());
    }
    public void Ball7Reward(int index)
    {
        BallSpawner.Instance.ColorIndex = index;
        for (int i = 0; i < Geekplay.Instance.PlayerData.BallEnabled.Length; i++)
        {
            Geekplay.Instance.PlayerData.BallEnabled[i] = false;
        }
        Geekplay.Instance.PlayerData.BallEnabled[index] = true;
        Geekplay.Instance.PlayerData.BallsBought[index] = true;
        StartCoroutine(WaitAFrameForMarket());
    }

    public void PressedBall8(int index)
    {
        if (Geekplay.Instance.PlayerData.BallsBought[index])
        {
            BallSpawner.Instance.ColorIndex = index;
            for (int i = 0; i < Geekplay.Instance.PlayerData.BallEnabled.Length; i++)
            {
                Geekplay.Instance.PlayerData.BallEnabled[i] = false;
            }
            Geekplay.Instance.PlayerData.BallEnabled[index] = true;
        }
        StartCoroutine(WaitAFrameForMarket());
    }
    public void PressedBall9(int index)
    {
        if (Geekplay.Instance.PlayerData.BallsBought[index])
        {
            BallSpawner.Instance.ColorIndex = index;
            for (int i = 0; i < Geekplay.Instance.PlayerData.BallEnabled.Length; i++)
            {
                Geekplay.Instance.PlayerData.BallEnabled[i] = false;
            }
            Geekplay.Instance.PlayerData.BallEnabled[index] = true;
        }
        StartCoroutine(WaitAFrameForMarket());
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
