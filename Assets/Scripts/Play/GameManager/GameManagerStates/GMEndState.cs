using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMEndState : BaseState
{
    private Player player;
    private Boss boss;
    private EnvironmentManager enviroManager;
    private GameUI gameUI;

    public GMEndState(Player _player, Boss _boss, EnvironmentManager _enviro, GameUI _gameUI)
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
        gameUI.stateMachine.ChangeState(gameUI.gameUIEndState);
    }
}
