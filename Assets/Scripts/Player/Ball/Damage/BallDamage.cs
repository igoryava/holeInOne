using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDamage : MonoBehaviour
{
    [SerializeField] private BallHealth _health;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<IBallCollisionDamagable>(
            out IBallCollisionDamagable ballCollisionDamagable))
        {
            _health.TakeDamage(ballCollisionDamagable.Damage);
        }
    }
}