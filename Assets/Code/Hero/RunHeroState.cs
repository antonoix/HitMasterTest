using UnityEngine.AI;
using UnityEngine;

public class RunHeroState : HeroState
{
    public RunHeroState(Transform hero, IStateProvider provider, Point firstPoint)
        : base(hero, provider, firstPoint) { }

    public override void Enter()
    {
        _anim.SetBool("Run", true);
        _agent.updateRotation = true;
        _agent.SetDestination(_point.transform.position);
    }

    public override void Update()
    {
        //throw new System.NotImplementedException();
    }

    public override void HandleScreenTouch(Vector3 pos)
    {
        _attackSystem.Attack(pos);
    }

    public override void ReachLocation(Point point)
    {
        _provider.SetState<StayHeroState>();
    }

    public override void PassLocation(Point nextDestination)
    {
        _point = nextDestination;
        _agent.SetDestination(_point.transform.position);
    }

    public override void HandleWin()
    {
        _provider.SetState<StayHeroState>();
    }
}
