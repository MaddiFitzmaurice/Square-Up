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
        
    }

    public override void LogicUpdate()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            boss.stateMachine.ChangeState(boss.bossSpongeState);
        }
    }

    public override void PhysicsUpdate()
    {
        boss.bossMovement.ResetRotation();
    }
}
