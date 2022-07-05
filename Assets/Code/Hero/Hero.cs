using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour, IStateProvider
{
    private InputSystem _input;

    #region States
    private HeroState _currentState;
    private List<HeroState> _states;
    #endregion

    private void Awake()
    {
        _input = new PCInput();
        _input.OnClicked += HandleScreenTouch;
    }

    public void InitStates(Point firstPoint)
    {
        _states = new List<HeroState>
        {
            new RunHeroState(transform, this, firstPoint),
            new StayHeroState(transform, this, firstPoint)
        };
    }

    public void HandlePointReached(Point point)
    {
        _currentState.ReachLocation(point);
    }

    public void HandleLocationPassed(Point nextPoint)
    {
        _currentState.PassLocation(nextPoint);
    }

    public void HandleWin()
    {
        _currentState.HandleWin();
    }

    private void HandleScreenTouch(Vector3 pos)
    {
        if (_currentState == null)
        {
            SetState<RunHeroState>();
            return;
        }
        _currentState.HandleScreenTouch(pos);
    }

    public void SetState<T>() where T : HeroState
    {
        _currentState = _states.Find(state => state is T);
        _currentState.Enter();
    }

    public void Update()
    {
        _input.Update();
        if (_currentState != null)
            _currentState.Update();
    }
}