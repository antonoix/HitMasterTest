using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Hero _hero;
    [SerializeField] private LocationsHolder _locationsHolder;
    [SerializeField] private UIManager _UI;


    void Awake()
    {
        _locationsHolder.OnLocationReached += HandleLocationReached;
        _locationsHolder.OnLocationPassed += HandleLocationPassed;
        _locationsHolder.OnAllLocationsPassed += HandleFinish;
    }

    private void Start()
    {
        _hero.CurrentPoint = _locationsHolder.GetFirstLocation.Point;
    }

    private void HandleLocationReached(Location location)
    {
        _hero.CurrentPoint = location.Point;
        _hero.SetStayState();
    }

    private void HandleLocationPassed(Location newLocation)
    {
        _UI.UpdateProgress(_locationsHolder.ÑurrentLocation, _locationsHolder.LocationsCount);
        _hero.CurrentPoint = newLocation.Point;
        _hero.SetRunState();
    }

    private void HandleFinish()
    {
        _UI.UpdateProgress(1, 1);
        _hero.SetStayState();
        _UI.ActivateRestart();
    }
}

