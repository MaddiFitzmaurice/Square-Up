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
        boss.bossAttacks.StartAttack(boss.bossAttacks.singleFire, boss.bossData.bpStartTime, boss.bossData.bpFireRate);
    }

    public override void LogicUpdate()
    {
        
    }

    public override void PhysicsUpdate()
    {
        boss.bossMovement.LookAtPlayer();
    }

    public override void Exit()
    {
        boss.bossAttacks.StopAttack();
    }
}
