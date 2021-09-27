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
        boss.bossHealthManager.weakHitbox.enabled = true;
    }

    public override void LogicUpdate()
    {
       
    }

    public override void PhysicsUpdate()
    {

    }

    public override void Exit()
    {
        boss.bossHealthManager.weakHitbox.enabled = false;
        boss.bossHealthManager.ResetShields();
    }

}
