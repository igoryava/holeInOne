using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallWin : MonoBehaviour
{
    private bool _winned;

    public event Action Winned;

    public void ResetWin()
    {
        _winned = false;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<IWinCollidable>(out IWinCollidable winCollidable))
        {
            Win();
        }
    }

    public void Win()
    {
        if (!_winned)
        {
            _winned = true;
            Winned?.Invoke();
        }
    }
}