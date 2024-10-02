using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI MoneyText;
    private void Start()
    {
        if(Geekplay.Instance.PlayerData.Income == 0)
        {
            Geekplay.Instance.PlayerData.Income = 1;
            Geekplay.Instance.Save();
        }
        MoneyText.text = "$" + Geekplay.Instance.PlayerData.MoneyCount.ToString();
    }
    public void AddMoney()
    {
        Geekplay.Instance.PlayerData.MoneyCount = (Geekplay.Instance.PlayerData.MoneyCount + Geekplay.Instance.PlayerData.Income);
        MoneyText.text = "$" + Geekplay.Instance.PlayerData.MoneyCount.ToString();
        Geekplay.Instance.Save();
    }
}
