using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Equipable : MonoBehaviour
{
    [field: SerializeField] public int ID { get; private  set; }
    [SerializeField] private GameObject _equipButton;
    [SerializeField] private TextMeshProUGUI _equipText;
    private void OnEnable()
    {
        _equipButton.SetActive(true);
    }

    public void GetEquiped()
    {
        PlayerPrefs.SetInt("Skin", ID);
        _equipText.text = "EQUIPED";
    }

    public void GetUnEquiped()
    {
        _equipText.text = "EQUIP";
    }
}
