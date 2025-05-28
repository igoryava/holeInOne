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
                _rate = "PERFECT";
                break;
            case 2:
                _accuracy = 50;
                _rate = "GOOD";
                break;
            case 1:
                _rate = "GOOD";
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
    }

    private void OnDisable()
    {
        _health.Dead -= OnDead;
        _health.HealthValueChanged -= OnHealthValueChanged;
        _win.Winned -= ShowStats;
    }
}