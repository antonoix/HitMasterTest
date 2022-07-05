using System;
using System.Collections.Generic;
using UnityEngine;

public class LocationsHolder : MonoBehaviour
{
    public event Action<Point> OnPointReached;
    public event Action<Location> OnLocationPassed;
    public event Action OnAllLocationsPassed;

    [SerializeField] private Location[] _locations;

    public int LocationsCount { get; private set; } 
    public int CurrentLocation { get; private set; }

    void Awake()
    {
        LocationsCount = _locations.Length;
        foreach (var location in _locations)
        {
            location.OnLocationPassed += HandleLocationPassed;
            location.OnLocationReached += HandleLocationReached;
        }
    }

    public Location GetFirstLocation => _locations[0];

    private void HandleLocationPassed(Location location)
    {
        if (CurrentLocation == _locations.Length - 1)
        {
            OnAllLocationsPassed?.Invoke();
            return;
        }
        OnLocationPassed?.Invoke(_locations[++CurrentLocation]);
    }

    private void HandleLocationReached(Location location)
    {
        OnPointReached?.Invoke(_locations[CurrentLocation].Point);
    }
}
