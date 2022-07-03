using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy
{
    protected override void Start()
    {
        _startHealth = 5;
        base.Start();

    }
}
