using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleEnemy : Enemy
{
    protected override void Start()
    {
        _startHealth = 15;
        base.Start();
    }
}
