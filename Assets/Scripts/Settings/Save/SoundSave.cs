using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSave : MonoBehaviour
{
    [SerializeField] private string _key;
    [SerializeField] private string _saveKey;
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Sprite _offSpite;
    [SerializeField] private Image _image;

    private void Start()
    {
        if (PlayerPrefs.GetInt(_saveKey, 1) == 0)
        {
            _mixer.SetFloat(_key, -80);
            _text.text = "OFF";
            _image.sprite = _offSpite;
        }
    }
}