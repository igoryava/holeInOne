using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private GameObject _settingsCanvas;
    [SerializeField] private GameObject _menuCanvas;
    [SerializeField] private int _maxLevels;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Sprite _onSprite;
    [SerializeField] private Sprite _offSprite;
    [SerializeField] private string _musicKey;
    [SerializeField] private string _soundKey;
    [SerializeField] private string _onText;
    [SerializeField] private string _offText;

    private GameObject _currentPanel;

    private void Start()
    {
        Time.timeScale = 1;
        _currentPanel = _menuCanvas;
        PlayerPrefs.GetInt("Music", 20);
        PlayerPrefs.GetInt("Sound", 20);
    }

    public void OpenClosePanel(GameObject panel)
    {
        _currentPanel.SetActive(false);
        panel.SetActive(true);
        _currentPanel = panel;
        if (_settingsCanvas.activeSelf)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void OnVolumeMusicChanged(TextMeshProUGUI text)
    {
        SwitchOnOff(text, _musicKey);
        if (text.text == _onText)
        {
            PlayerPrefs.SetInt("Music", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Music", 0);
        }
    }

    public void OnVolumeSoundChanged(TextMeshProUGUI text)
    {
        SwitchOnOff(text, _soundKey);
        if (text.text == _onText)
        {
            PlayerPrefs.SetInt("Sound", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Sound", 0);
        }
    }

    public void OnVibrationChanged(TextMeshProUGUI text)
    {
        if (text.text == _onText)
        {
            text.text = _offText;
        }
        else
        {
            text.text = _onText;
        }

        if (text.text == _onText)
        {
            PlayerPrefs.SetInt("Vibration", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Vibration", 0);
        }
    }


    public void Exit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Play()
    {
        int level = PlayerPrefs.GetInt("CompleatedLevels", 1);

        if (level == 1)
        {
            SceneManager.LoadScene("Game");
        }
        else
        {
            if (level >= _maxLevels)
            {
                PlayerPrefs.SetInt("CurrentLevel", 1);
                SceneManager.LoadScene("Game");
                return;
            }
            PlayerPrefs.SetInt("CurrentLevel", level);
            SceneManager.LoadScene("Game");
        }
    }

    private void SwitchOnOff(TextMeshProUGUI text, string key)
    {
        if (text.text == _onText)
        {
            text.text = _offText;
            _audioMixer.SetFloat(key, -80);
        }
        else
        {
            text.text = _onText;
            _audioMixer.SetFloat(key, 20);
        }
    }

    public void ChangeSprites(Image image)
    {
        if (image.sprite == _onSprite)
        {
            image.sprite = _offSprite;
        }
        else
        {
            image.sprite = _onSprite;
        }
    }
}