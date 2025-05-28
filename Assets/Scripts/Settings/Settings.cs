using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    [SerializeField] private GameObject _settingsCanvas;
    [SerializeField] private GameObject _menuCanvas;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private string _musicKey;
    [SerializeField] private string _soundKey;
    [SerializeField] private string _onText;
    [SerializeField] private string _offText;

    private GameObject _currentPanel;

    private void Start()
    {
        _currentPanel = _menuCanvas;
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
    }

    public void OnVolumeSoundChanged(TextMeshProUGUI text)
    {
        SwitchOnOff(text, _soundKey);
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
        
    }

    private void SwitchOnOff(TextMeshProUGUI text, string key)
    {
        if (text.text == _onText)
        {
            text.text = _offText;
            _audioMixer.SetFloat(key, 20);
        }
        else
        {
            text.text = _onText;
            _audioMixer.SetFloat(key, -80);
        }
    }
}
