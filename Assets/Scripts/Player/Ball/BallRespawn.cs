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

    public void Restart()
    {
        StartCoroutine(Respawning());
    }

    private IEnumerator Respawning()
    {
        _movement.Block();
        yield return new WaitForSeconds(_respawnDelay);
        _movement.UnBlock();

        transform.position = _spawnPoint.position;
        Restarted?.Invoke();
    }
}