using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private GameObject[] _levels;
    [SerializeField] private LevelReload _reload;

    public int CurrentLevel { get; private set; }

    private GameObject _currentLevel;

    public event Action LevelSwitched;

    public static LevelSelector Instance { get; private set; }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            return;
        }

        Debug.LogError("There`s one more LevelSelector");
        Debug.Break();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void Start()
    {
        CurrentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        _levels[CurrentLevel - 1].SetActive(true);
        _currentLevel = _levels[CurrentLevel - 1];
    }


    public void NextLevel()
    {
        PlayerPrefs.SetInt("CurrentLevel", CurrentLevel + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        return;
        CurrentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);

        _currentLevel.SetActive(false);

        _levels[CurrentLevel - 1].SetActive(true);
        _currentLevel = _levels[CurrentLevel - 1];
        if (CurrentLevel >= 1)
        {
            SceneManager.LoadScene("Menu");
            return;
        }

        _reload.Reload();
        LevelSwitched?.Invoke();
    }
}