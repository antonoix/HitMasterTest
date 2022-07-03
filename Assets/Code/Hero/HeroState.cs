using UnityEngine.AI;
using UnityEngine;

public abstract class HeroState
{
    protected Transform _hero;

    protected Animator _anim;
    protected AttackSystem _attackSystem;
    protected NavMeshAgent _agent;

    protected virtual void InitComponents()
    {
        _anim = _hero.GetComponent<Animator>();
        _agent = _hero.GetComponent<NavMeshAgent>();
        _attackSystem = _hero.GetComponent<AttackSystem>();
    }

    public abstract void Enter(Point point);

    public abstract void HandleScreenTouch(Vector3 pos);

    public abstract void Update();

    public abstract void Exit();
}
