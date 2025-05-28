using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHealthUI : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private GameObject[] _hearts;

    private void OnEnable()
    {
        _health.HealthValueChanged += OnHealthValueChanged;
        _health.OnHealedToMax += OnHealedToMax;
    }

    private void OnHealedToMax(float value)
    {
        for (int i = 0; i < _hearts.Length; i++)
        {
            _hearts[i].SetActive(true);
        }
    }

    private void OnHealthValueChanged(float value)
    {
        Debug.Log(value);
        if (value > 0)
        {
            _hearts[(int) value - 1].SetActive(false);
            return;
        }

        _hearts[_hearts.Length - 1].SetActive(false);
    }

    private void OnDisable()
    {
        _health.HealthValueChanged -= OnHealthValueChanged;
        _health.OnHealedToMax -= OnHealedToMax;
    }
}