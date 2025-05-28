using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Balance : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _balanceText;
    [SerializeField] private int _startBalance;
    public int CurrentBalance { get; private set; }


    private void Start()
    {
        CurrentBalance = PlayerPrefs.GetInt("Money", _startBalance);
        _balanceText.text = CurrentBalance.ToString();
    }

    public void SpendMoney(int price)
    {
        if (CurrentBalance - price < 0)
        {
            return;
        }
        CurrentBalance -= price;
        _balanceText.text = CurrentBalance.ToString();
        PlayerPrefs.SetInt("Money", CurrentBalance);
    }
    
    public void EarnMoney(int gain)
    {
        CurrentBalance += gain;
        _balanceText.text = CurrentBalance.ToString();
        PlayerPrefs.SetInt("Money", CurrentBalance);
    }
}
