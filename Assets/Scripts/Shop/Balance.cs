using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Balance : MonoBehaviour
{
    [SerializeField] private int _startBalance;
    public int CurrentBalance { get; private set; }
    public event Action<int> BalanceChanged;


    private void Start()
    {
        CurrentBalance = PlayerPrefs.GetInt("Money", _startBalance);
    }

    public void SpendMoney(int price, Buyable buyable)
    {
        if (CurrentBalance - price < 0)
        {
            return;
        }
        buyable.GetBought();
        CurrentBalance -= price;
        BalanceChanged?.Invoke(CurrentBalance);
        PlayerPrefs.SetInt("Money", CurrentBalance);
    }
    
    public void EarnMoney(int gain)
    {
        CurrentBalance += gain;
        BalanceChanged?.Invoke(CurrentBalance);
        PlayerPrefs.SetInt("Money", CurrentBalance);
    }
}
