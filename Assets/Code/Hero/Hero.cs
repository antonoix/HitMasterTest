using UnityEngine;

public class Hero : MonoBehaviour
{
    private InputSystem _input;

    #region States
    private HeroState _currentState;
    private RunHeroState _runState;
    private StayHeroState _stayState;
    #endregion

    public Point CurrentPoint;

    private void Awake()
    {
        _input = new PCInput();
        _input.OnClicked += HandleScreenTouch;
        InitStates();
    }

    private void InitStates()
    {
        _runState = new RunHeroState(transform);
        _stayState = new StayHeroState(transform);
    }

    public void HandleScreenTouch(Vector3 pos)
    {
        if (_currentState == null)
        {
            SetRunState();
            return;
        }

        _currentState.HandleScreenTouch(pos);
    }

    public void SetRunState()
    {
        ExitPreviousState();
        _currentState = _runState;
        _currentState.Enter(CurrentPoint);
    }

    public void SetStayState()
    {
        ExitPreviousState();
        _currentState = _stayState;
        _currentState.Enter(CurrentPoint);
    }

    private void ExitPreviousState()
    {
        if (_currentState != null)
            _currentState.Exit();
    }

    public void Update()
    {
        _input.Update();
        if (_currentState != null)
            _currentState.Update();
    }
}