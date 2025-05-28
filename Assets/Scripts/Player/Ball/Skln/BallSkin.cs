using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSkin : MonoBehaviour
{
    [SerializeField] private GameObject[] _skins;

    private void Start()
    {
        _skins[PlayerPrefs.GetInt("Skin", 1) - 1].SetActive(true);
    }
}