using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRespawn : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private BallMovement _movement;
    [SerializeField] private float _respawnDelay;

    public event Action Restarted;

    public bool IsRespawning { get; private set; }

    public void Restart()
    {
        StartCoroutine(Respawning());
    }

    private IEnumerator Respawning()
    {
        IsRespawning = true;
        _movement.Block();
        yield return new WaitForSeconds(_respawnDelay);
        QuickRespawn();
        IsRespawning = false;
    }

    public void QuickRespawn()
    {
        _movement.UnBlock();

        transform.position = _spawnPoint.position;
        Restarted?.Invoke();
    }
}