using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _level;

    private void Start()
    {
        _level.text = "LEVEL " + PlayerPrefs.GetInt("CurrentLevel", 1);
    }

    private void OnEnable()
    {
        LevelSelector.Instance.LevelSwitched += OnLevelSwitched;
        OnLevelSwitched();
    }

    private void OnLevelSwitched()
    {
        _level.text = "LEVEL " + PlayerPrefs.GetInt("CurrentLevel", 1);
    }

    private void OnDisable()
    {
        LevelSelector.Instance.LevelSwitched -= OnLevelSwitched;
    }
}