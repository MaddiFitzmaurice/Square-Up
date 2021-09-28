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
        // Begin Single Fire
        boss.bossAttacks.StartRepeatingAttack(boss.bossAttacks.singleFire, boss.bossData.singleFireStartTime, boss.bossData.singleFireRate);
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
