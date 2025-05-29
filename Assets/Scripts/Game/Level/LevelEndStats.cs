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
    [SerializeField] private Balance _balance;
    [SerializeField] private GameObject _continueButton;
    [SerializeField] private LevelSelector _levelSelector;
    [SerializeField] private int _gain;
    [SerializeField] private int _maxLevel;

    [SerializeField] private BallHealth _health;
    [SerializeField] private BallWin _win;

    private int _attemps = 1;
    private int _accuracy = 100;
    private string _rate = "PERFECT";
    private int _stars = 3;

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
        Debug.Log(_levelSelector.CurrentLevel);
        if (_levelSelector.CurrentLevel >= _maxLevel)
        {
            _continueButton.SetActive(false);
        }
        _accuracyText.text = _accuracy.ToString() + "%";
        _attemptsText.text = _attemps.ToString();
        _rateText.text = _rate;
        SaveStats();
        Debug.Log(PlayerPrefs.GetInt(PlayerPrefs.GetInt("CurrentLevel", 1) + "Stars", _stars));
    }

    private void SaveStats()
    {
        _balance.EarnMoney(_gain);
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        PlayerPrefs.SetInt(currentLevel + "Stars", _stars);

        if (currentLevel < PlayerPrefs.GetInt("CompleatedLevels", currentLevel))
            return;

        if (currentLevel == 10)
        {
            PlayerPrefs.SetInt("CompleatedLevels", 10);
            return;
        }

        PlayerPrefs.SetInt("CompleatedLevels", currentLevel + 1);
    }

    private void OnDisable()
    {
        _health.Dead -= OnDead;
        _health.HealthValueChanged -= OnHealthValueChanged;
        _win.Winned -= ShowStats;
    }
}