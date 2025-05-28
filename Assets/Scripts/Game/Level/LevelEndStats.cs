using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelEndStats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _accuracyText;
    [SerializeField] private TextMeshProUGUI _attemptsText;
    [SerializeField] private TextMeshProUGUI _rateText;

    [SerializeField] private BallHealth _health;
    [SerializeField] private BallWin _win;

    private int _attemps = 1;
    private int _accuracy = 100;
    private string _rate = "PERFECT";
    private int _stars;

    private void OnEnable()
    {
        _health.Dead += OnDead;
        _health.HealthValueChanged += OnHealthValueChanged;
        _win.Winned += ShowStats;
    }

    private void OnHealthValueChanged(float value)
    {
        switch (value)
        {
            case 3:
                _accuracy = 100;
                _stars = 3;
                _rate = "PERFECT";
                break;
            case 2:
                _accuracy = 50;
                _stars = 2;
                _rate = "GOOD";
                break;
            case 1:
                _rate = "GOOD";
                _stars = 1;
                _accuracy = 33;
                break;
        }
    }

    public void ResetStats()
    {
        _attemps = 1;
        _accuracy = 100;
        _rate = "PERFECT";
    }

    private void OnDead()
    {
        _attemps++;
    }

    public void ShowStats()
    {
        _accuracyText.text = _accuracy.ToString() + "%";
        _attemptsText.text = _attemps.ToString();
        _rateText.text = _rate;
        SaveStats();
    }

    private void SaveStats()
    {
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        PlayerPrefs.SetInt(currentLevel + "Stars", _stars);
        PlayerPrefs.SetInt("CompleatedLevels", currentLevel);
    }

    private void OnDisable()
    {
        _health.Dead -= OnDead;
        _health.HealthValueChanged -= OnHealthValueChanged;
        _win.Winned -= ShowStats;
    }
}