using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Buyable : MonoBehaviour
{
    [field: SerializeField] public int Price { get; private set; }
    [field: SerializeField] public bool Bought { get; private  set; }
    [field: SerializeField] public GameObject BuyButton { get; private  set; }
    [field: SerializeField] public TextMeshProUGUI Text { get; private  set; }
    [field: SerializeField] public int ID { get; private  set; }

    [SerializeField] private Equipable _equipable;

    private void Start()
    {
        Text.text = Price.ToString();
        if (PlayerPrefs.GetInt("Skin" + ID, 0) == 1)
        {
            Bought = true;
            _equipable.enabled = true;
            BuyButton.SetActive(false);
        }
    }

    public void GetBought()
    {
        _equipable.enabled = true;
        Bought = true;
        PlayerPrefs.SetInt("Skin" + ID, 1);
        PlayerPrefs.SetInt("Skin", ID);
        BuyButton.SetActive(false);
    }
}
