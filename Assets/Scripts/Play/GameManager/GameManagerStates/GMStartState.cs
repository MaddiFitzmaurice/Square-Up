using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMStartState : BaseState
{
    private Player player;
    private Boss boss;
    private EnvironmentManager enviroManager;

    public GMStartState(Player _player, Boss _boss, EnvironmentManager _enviroManager)
    {
        player = _player;
        boss = _boss;
        enviroManager = _enviroManager;
    }

    public override void Enter()
    {
        player.stateMachine.ChangeState(player.playerStartState);
        boss.stateMachine.ChangeState(boss.bossStartState);
        //enviro.
    }

    public override void LogicUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.instance.gmStateMachine.ChangeState(GameManager.instance.gmEvadeState);
        }

        player.stateMachine.currentState.LogicUpdate();
        boss.stateMachine.currentState.LogicUpdate();
        //enviroManager.stateMachine.currentState.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        player.stateMachine.currentState.PhysicsUpdate();
        boss.stateMachine.currentState.PhysicsUpdate();
        //enviroManager.stateMachine.currentState.PhysicsUpdate();
    }
}
