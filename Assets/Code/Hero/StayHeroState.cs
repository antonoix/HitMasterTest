using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayHeroState : HeroState
{
    private Transform _rotation;

    public StayHeroState(Transform hero)
    {
        _hero = hero;
        InitComponents();
    }

    public override void Enter(Point point)
    {
        _anim.SetBool("Run", false);
        _rotation = point.transform;
        _agent.updateRotation = false;
    }

    public override void Exit()
    {
        _agent.updateRotation = true;
    }

    public override void HandleScreenTouch(Vector3 pos)
    {
        _attackSystem.Attack(pos);
    }

    public override void Update()
    {
        _hero.transform.rotation = Quaternion.Lerp(_hero.transform.rotation, _rotation.rotation,
            Time.deltaTime);
    }
}
