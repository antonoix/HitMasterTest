using System;
using System.Collections.Generic;
using UnityEngine;

public class LocationsHolder : MonoBehaviour
{
    public event Action<Location> OnLocationReached;
    public event Action<Location> OnLocationPassed;
    public event Action OnAllLocationsPassed;

    [SerializeField] private Location[] _locations;

    public int LocationsCount { get; private set; } 
    public int ŅurrentLocation { get; private set; }

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
        if (ŅurrentLocation == _locations.Length - 1)
        {
            OnAllLocationsPassed?.Invoke();
            return;
        }
        Debug.Log(ŅurrentLocation + " locationPassed");
        OnLocationPassed?.Invoke(_locations[++ŅurrentLocation]);
    }

    private void HandleLocationReached(Location location)
    {
        OnLocationReached?.Invoke(_locations[ŅurrentLocation]);
    }
}
