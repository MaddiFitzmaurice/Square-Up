using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossNoGravState : BaseState
{
    private Boss boss;

    public BossNoGravState(Boss _boss)
    {
        boss = _boss;
    }

    public override void Enter()
    {
        boss.bossHealthManager.ResetShields();
        boss.bossAttacks.BeginAttackPhases();
    }

    public override void LogicUpdate()
    {
        
    }

    public override void PhysicsUpdate()
    {
        if (boss.bossAttacks.isSpinning)
        {
            boss.bossMovement.SpinAround();
        }
        else
        {
            boss.bossMovement.LookAtPlayer();
        }
    }

    public override void Exit()
    {
        boss.bossAttacks.ClearMinesEarly();
    }
}
