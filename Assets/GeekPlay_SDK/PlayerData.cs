using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public event Action<int> CoinsChanged;
    public int _coinsDontUse;
    /////InApps//////
    public string lastBuy;
    public int Coins { 
        get
        {
            return _coinsDontUse;
        }
        set
        {
            _coinsDontUse = value;
            CoinsChanged?.Invoke(_coinsDontUse);
        }
    }

    public int Income;
    public int BallHealth;
    public int MaxSpawnCount;
    public float BallSpeed;
    public int BallPower;

    public float HealthPrice;
    public float PowerPrice;
    public float CountPrice;


    public float IncomePrice;
    public int MoneyToAdd;
    public int RebornCount;

    public int Level;

    public string LastSaveTime;
    public bool IsNotFirstTime;
}