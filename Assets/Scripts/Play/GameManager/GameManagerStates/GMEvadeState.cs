using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMEvadeState : BaseState
{
    private Player player;
    private Boss boss;
    private EnvironmentManager enviroManager;

    public GMEvadeState(Player _player, Boss _boss, EnvironmentManager _enviro)
    {
        player = _player;
        boss = _boss;
        enviroManager = _enviro;
    }

    public override void Enter()
    {
        player.stateMachine.ChangeState(player.playerNoGravState);
        boss.stateMachine.ChangeState(boss.bossNoGravState);
        enviroManager.stateMachine.ChangeState(enviroManager.enviroEvadeState);
    }

    public override void LogicUpdate()
    {
        if (boss.bossAttacks.chainComplete)
        {
            GameManager.instance.gmStateMachine.ChangeState(GameManager.instance.gmSpongeState);
        }

        player.stateMachine.currentState.LogicUpdate();
        boss.stateMachine.currentState.LogicUpdate();
        enviroManager.stateMachine.currentState.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        player.stateMachine.currentState.PhysicsUpdate();
        boss.stateMachine.currentState.PhysicsUpdate();
        enviroManager.stateMachine.currentState.PhysicsUpdate();
    }
}
