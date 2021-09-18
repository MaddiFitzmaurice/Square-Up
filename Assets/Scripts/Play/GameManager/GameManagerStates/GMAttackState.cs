using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMAttackState : BaseState
{
    private Player player;
    private Boss boss;
    private EnvironmentManager enviroManager;

    public GMAttackState(Player _player, Boss _boss, EnvironmentManager _enviroManager)
    {
        player = _player;
        boss = _boss;
        enviroManager = _enviroManager;
    }

    public override void Enter()
    {
        //player.stateMachine.ChangeState(player.playerGravState);
        boss.stateMachine.ChangeState(boss.bossWeakState);
        enviroManager.stateMachine.ChangeState(enviroManager.enviroLaunchState);
    }
}
