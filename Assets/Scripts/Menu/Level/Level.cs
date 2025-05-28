using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] private int _number;
    [SerializeField] private GameObject _lock;
    [SerializeField] private Button _button;

    [SerializeField] private Image[] _starHolders;
    [SerializeField] private Sprite _rateStar;

    private void Awake()
    {
        if (_number == 1)
        {
            SetRate();
            return;
        }

        if (PlayerPrefs.GetInt("CompleatedLevels", 1) + 1 == _number)
        {
            SetRate();
            return;
        }

        if (PlayerPrefs.GetInt("CompleatedLevels", 1) < _number)
        {
            Lock();
            return;
        }

        SetRate();
    }

    public void Load()
    {
        PlayerPrefs.SetInt("CurrentLevel", _number);
        SceneManager.LoadScene("Game");
    }

    private void SetRate()
    {
        for (int i = 0; i < PlayerPrefs.GetInt(_number + "Stars", 0); i++)
        {
            _starHolders[i].sprite = _rateStar;
        }
    }

    private void Lock()
    {
        _button.enabled = false;
        _lock.SetActive(true);
    }
}