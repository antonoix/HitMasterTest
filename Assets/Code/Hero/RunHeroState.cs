using UnityEngine.AI;
using UnityEngine;

public class RunHeroState : HeroState
{
    public RunHeroState(Transform hero)
    {
        _hero = hero;
        InitComponents();
    }

    public override void Enter(Point point)
    {
        _anim.SetBool("Run", true);
        _agent.SetDestination(point.transform.position);
    }

    public override void Update()
    {
        //throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        //throw new System.NotImplementedException();
    }

    public override void HandleScreenTouch(Vector3 pos)
    {
        _attackSystem.Attack(pos);
    }
}
