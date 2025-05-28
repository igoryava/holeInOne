using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelReload : MonoBehaviour
{
    [SerializeField] private LevelEndStats _stats;
    [SerializeField] private BallHealth _health;
    [SerializeField] private BallWin _win;
    [SerializeField] private BallRespawn _respawn;

    public void Reload()
    {
        Time.timeScale = 1;
        _stats.ResetStats();
        _health.HealToMax();
        _win.ResetWin();
        _respawn.Restart();
    }
}