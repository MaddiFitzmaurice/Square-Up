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
        boss.bossAttacks.StartAttack(boss.bossAttacks.singleFire, boss.bossData.bpStartTime, boss.bossData.bpFireRate);
    }

    public override void LogicUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            boss.bossAttacks.StopAttack();
            boss.bossAttacks.StartAttack(boss.bossAttacks.areaFire, boss.bossData.bpStartTime, boss.bossData.areaFireRate);
        }
    }

    public override void PhysicsUpdate()
    {
        boss.bossMovement.LookAtPlayer();
    }
}
