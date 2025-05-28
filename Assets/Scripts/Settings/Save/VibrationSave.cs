using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VibrationSave : MonoBehaviour
{
    [SerializeField] private string _saveKey;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Sprite _offSpite;
    [SerializeField] private Image _image;

    private void Start()
    {
        if (PlayerPrefs.GetInt(_saveKey, 1) == 0)
        {
            _text.text = "OFF";
            _image.sprite = _offSpite;
        }
    }
}