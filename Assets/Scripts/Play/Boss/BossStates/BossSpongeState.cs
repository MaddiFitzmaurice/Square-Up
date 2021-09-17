using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpongeState : BaseState
{
    private Boss boss;

    public BossSpongeState(Boss _boss)
    {
        boss = _boss;
    }

    public override void Enter()
    {
        boss.bossHealthManager.ResetShields();
        boss.bossAttacks.StartSingleFire();
    }

    public override void LogicUpdate()
    {
        if (boss.bossData.shieldHealth == 0)
        {
            GameManager.instance.gmStateMachine.ChangeState(GameManager.instance.gmAttackState);
        }
    }

    public override void PhysicsUpdate()
    {
        boss.bossMovement.LookAtPlayer();
    }

    public override void Exit()
    {
        boss.bossAttacks.StopSingleFire();
    }
}
