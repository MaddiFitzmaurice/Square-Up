using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeakState : BaseState
{
    private Boss boss;

    public BossWeakState(Boss _boss)
    {
        boss = _boss;
    }

    public override void Enter()
    {
        boss.bossMovement.ResetRotation();
    }

    public override void LogicUpdate()
    {
       
    }

    public override void PhysicsUpdate()
    {
      
    }

}
