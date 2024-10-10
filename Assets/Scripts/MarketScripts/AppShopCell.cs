using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AppShopCell : MonoBehaviour
{
    public string PurName;
    public Button BuyDollarButton;
    [SerializeField] TextMeshProUGUI DollarCount;
    [SerializeField] private bool isNotDollar;
    [SerializeField] private MarketScript _marketScript;
    [SerializeField] private int index;
    [SerializeField] private bool isBallButton;
    private void Start()
    {
        SubscribeOnPurchase();
        if (!isNotDollar)
        {
            DollarCount.text = Rewarder.Instance.GetDiamondCountByName(PurName).ToString();
        }
    }   
    public void SubscribeOnPurchase()
    {
        if (isBallButton)
        {
            if ((!Geekplay.Instance.PlayerData.BallsBought[index]))
            {
                BuyDollarButton.onClick.AddListener(delegate { InAppOperation(); });
            }
            else
            {
                BuyDollarButton.onClick.AddListener(() => _marketScript.PressedBall9(index));
            }
        }
        else
        {
            BuyDollarButton.onClick.AddListener(delegate { InAppOperation(); });
        }
    }
   
    private void InAppOperation()
    {
        Geekplay.Instance.RealBuyItem(PurName);
    }    
}