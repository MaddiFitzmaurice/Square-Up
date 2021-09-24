using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMAttackState : BaseState
{
    private Player player;
    private Boss boss;
    private EnvironmentManager enviroManager;

    private float time;

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

        // Keep track of time passed in this state
        time = 0;
    }

    public override void LogicUpdate()
    {
        // If failed to attack Boss in time, change back to Evade State
        if (time > GameManager.instance.gameData.attackStateFailedTime)
        {
            GameManager.instance.gmStateMachine.ChangeState(GameManager.instance.gmEvadeState);
        }

        time += Time.deltaTime;
    }
}
