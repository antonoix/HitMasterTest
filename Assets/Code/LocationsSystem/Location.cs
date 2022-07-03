using System;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public event Action<Location> OnLocationPassed;
    public event Action<Location> OnLocationReached;

    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private Point _point;
    public Point Point { get => _point; }

    private bool _isPassed;

    void Awake()
    {
        _point.OnTouched += HandlePointTouch;

        foreach (var enemy in _enemies)
        {
            enemy.OnDied += HandleDeath;
        }
    }

    private void HandleDeath(Enemy enemy)
    {
        _enemies.Remove(enemy);
        ChekIfPassed();
    }

    private void HandlePointTouch()
    {
        if (ChekIfPassed())
            return;
        if (_enemies.Count > 0)
            OnLocationReached?.Invoke(this);
    }

    private bool ChekIfPassed()
    {
        if (_enemies.Count == 0 && !_isPassed)
        {
            OnLocationPassed?.Invoke(this);
            _isPassed = true;
            return true;
        }
        return false;
    }
}
