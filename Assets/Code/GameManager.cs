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
        _locationsHolder.OnPointReached += _hero.HandlePointReached;
        _locationsHolder.OnLocationPassed += HandleLocationPassed;
        _locationsHolder.OnAllLocationsPassed += HandleFinish;
    }

    private void Start()
    {
        _hero.InitStates(_locationsHolder.GetFirstLocation.Point);
    }

    private void HandleLocationPassed(Location newLocation)
    {
        _UI.UpdateProgress(_locationsHolder.CurrentLocation, _locationsHolder.LocationsCount);
        _hero.HandleLocationPassed(newLocation.Point);
    }

    private void HandleFinish()
    {
        _hero.HandleWin();
        _UI.UpdateProgress(1, 1);
        _UI.ActivateRestart();
    }
}

