using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableSettings : MonoBehaviour
{
    [SerializeField] private GameObject _settings;
    [SerializeField] private BallMovement _ball;
    [SerializeField] private BallRespawn _respawn;

    private bool _locked;

    public void EnableDisable()
    {
        _settings.SetActive(!_settings.activeSelf);
        Debug.Log(_locked);
        if (_respawn.IsRespawning)

            _respawn.StopAllCoroutines();
        if (_locked)
        {
            _ball.gameObject.SetActive(true);
            if (_respawn.IsRespawning)
                _respawn.QuickRespawn();
            _locked = false;
        }
        else
        {
            _ball.gameObject.SetActive(false);
            _locked = true;
        }
    }
}