using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BalanceUI : MonoBehaviour
{
    [SerializeField] private Balance _balance;
    [SerializeField] private TextMeshProUGUI _balanceText;

    private void OnEnable()
    {
        _balance.BalanceChanged += ChangeBalance;
    }

    private void Start()
    {
        _balanceText.text = _balance.CurrentBalance.ToString();
    }

    public void ChangeBalance(int currentBalance)
    {
        _balanceText.text = _balance.CurrentBalance.ToString();
    }

    private void OnDisable()
    {
        _balance.BalanceChanged -= ChangeBalance;
    }
}
