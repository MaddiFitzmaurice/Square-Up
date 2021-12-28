using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMSpongeState : BaseState
{
    private Player player;
    private Boss boss;
    private EnvironmentManager enviroManager;
    private GameUI gameUI;

    private float time;

    public GMSpongeState(Player _player, Boss _boss, EnvironmentManager _enviroManager, GameUI _gameUI)
    {
        player = _player;
        boss = _boss;
        enviroManager = _enviroManager;
        gameUI = _gameUI;
    }

    public override void Enter()
    {
        player.stateMachine.ChangeState(player.playerGravState);
        boss.stateMachine.ChangeState(boss.bossSpongeState);
        enviroManager.stateMachine.ChangeState(enviroManager.enviroSpongeState);
        gameUI.stateMachine.ChangeState(gameUI.gameUIPlayState);
        // Keep track of time passed in this state
        time = 0;
    }

    public override void LogicUpdate()
    {
        // If player destroyed shield on time, change to Attack State
        if (boss.bossData.shieldHealth == 0)
        {
            GameManager.instance.gmStateMachine.ChangeState(GameManager.instance.gmAttackState);
        }

        // If player did not destroy shield on time, change back to Evade State
        if (time > GameManager.instance.gameData.spongeStateFailedTime)
        {
            GameManager.instance.gmStateMachine.ChangeState(GameManager.instance.gmEvadeState);
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

        time += Time.deltaTime;
    }

    public override void PhysicsUpdate()
    {
        player.stateMachine.currentState.PhysicsUpdate();
        boss.stateMachine.currentState.PhysicsUpdate();
        enviroManager.stateMachine.currentState.PhysicsUpdate();
    }
}
