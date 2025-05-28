using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsShop : MonoBehaviour
{
    [SerializeField] private Balance _balance;

    public void Buy(Buyable buyable)
    {
        if (!buyable.Bought && _balance.CurrentBalance > 0)
        {
            _balance.SpendMoney(buyable.Price);
            buyable.GetBought();
        }
    }
}
