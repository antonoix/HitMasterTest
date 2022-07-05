using UnityEngine;

public class StayHeroState : HeroState
{
    private Transform _rotation;

    public StayHeroState(Transform hero, IStateProvider provider, Point firstPoint)
        : base(hero, provider, firstPoint) { }

    public override void Enter()
    {
        _anim.SetBool("Run", false);
        _rotation = _point.transform;
        _agent.updateRotation = false;
    }

    public override void HandleScreenTouch(Vector3 pos)
    {
        _attackSystem.Attack(pos);
    }

    public override void HandleWin()
    {
        //throw new System.NotImplementedException();
    }

    public override void PassLocation(Point nextDestination)
    {
        _point = nextDestination;
        _provider.SetState<RunHeroState>();
    }

    public override void ReachLocation(Point point)
    {
        //throw new System.NotImplementedException();
    }

    public override void Update()
    {
        _hero.transform.rotation = Quaternion.Lerp(_hero.transform.rotation, _rotation.rotation,
            Time.deltaTime);
    }
}
