using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMEvadeState : BaseState
{
    private Player player;
    private Boss boss;
    private EnvironmentManager enviroManager;
    private GameUI gameUI;

    public GMEvadeState(Player _player, Boss _boss, EnvironmentManager _enviro, GameUI _gameUI)
    {
        player = _player;
        boss = _boss;
        enviroManager = _enviro;
        gameUI = _gameUI;
    }

    public override void Enter()
    {
        player.stateMachine.ChangeState(player.playerNoGravState);
        boss.stateMachine.ChangeState(boss.bossNoGravState);
        enviroManager.stateMachine.ChangeState(enviroManager.enviroEvadeState);
        gameUI.stateMachine.ChangeState(gameUI.gameUIPlayState);
    }

    public override void LogicUpdate()
    {
        if (boss.bossAttacks.chainComplete)
        {
            GameManager.instance.gmStateMachine.ChangeState(GameManager.instance.gmSpongeState);
        }

        // If player dies, go to end screen
        if (player.playerData.health <= 0)
        {
            GameManager.instance.gmStateMachine.ChangeState(GameManager.instance.gmEndState);
        }

        player.stateMachine.currentState.LogicUpdate();
        boss.stateMachine.currentState.LogicUpdate();
        enviroManager.stateMachine.currentState.LogicUpdate();
        gameUI.stateMachine.currentState.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        player.stateMachine.currentState.PhysicsUpdate();
        boss.stateMachine.currentState.PhysicsUpdate();
        enviroManager.stateMachine.currentState.PhysicsUpdate();
    }
}
