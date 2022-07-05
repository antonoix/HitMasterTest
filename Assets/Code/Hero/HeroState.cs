using UnityEngine.AI;
using UnityEngine;

public abstract class HeroState
{
    protected Transform _hero;
    protected IStateProvider _provider;

    protected Animator _anim;
    protected AttackSystem _attackSystem;
    protected NavMeshAgent _agent;

    protected static Point _point;

    protected HeroState(Transform hero, IStateProvider provider , Point firstPoint)
    {
        _hero = hero;
        _provider = provider;
        _point = firstPoint;
        _anim = _hero.GetComponent<Animator>();
        _agent = _hero.GetComponent<NavMeshAgent>();
        _attackSystem = _hero.GetComponent<AttackSystem>();
    }

    public abstract void Enter();

    public abstract void HandleScreenTouch(Vector3 pos);

    public abstract void ReachLocation(Point point);

    public abstract void HandleWin();

    public abstract void PassLocation(Point nextDestination);

    public abstract void Update();
}
