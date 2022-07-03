using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardEnemy : Enemy
{
    protected override void Start()
    {
        _startHealth = 20;
        base.Start();
    }
}