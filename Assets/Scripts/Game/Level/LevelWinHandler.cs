using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWinHandler : MonoBehaviour
{
    [SerializeField] private BallWin _ball;
    [SerializeField] private GameObject _winPanel;

    private void OnEnable()
    {
        _ball.Winned += OnWinned;
    }

    private void OnWinned()
    {
        _winPanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        _ball.Winned -= OnWinned;
    }
}