using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHealth : Health
{
    [SerializeField] private BallRespawn _respawn;
    [SerializeField] private AudioSource _ballSound;

    private bool _restarted = true;

    public override void TakeDamage(float value)
    {
        base.TakeDamage(value);
        _ballSound.Play();
        if (!_restarted)
            return;
        _restarted = false;
        _respawn.Restart();
        _respawn.Restarted += OnRestarted;
    }

    public override void Death()
    {
        HealToMax();
    }

    private void OnDisable()
    {
        _respawn.Restarted -= OnRestarted;
    }

    private void OnRestarted()
    {
        _restarted = true;
    }
}