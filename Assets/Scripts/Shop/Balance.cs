using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Balance : MonoBehaviour
{
    [SerializeField] private int _startBalance;
    public int CurrentBalance { get; private set; }
    public event Action BalanceChanged;


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
        BalanceChanged?.Invoke();
        PlayerPrefs.SetInt("Money", CurrentBalance);
    }
    
    public void EarnMoney(int gain)
    {
        CurrentBalance += gain;
        Debug.Log(CurrentBalance);
        BalanceChanged?.Invoke();
        PlayerPrefs.SetInt("Money", CurrentBalance);
    }
}
