using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMSpongeState : BaseState
{
    private Player player;
    private Boss boss;
    private EnvironmentManager enviroManager;

    public GMSpongeState(Player _player, Boss _boss, EnvironmentManager _enviroManager)
    {
        player = _player;
        boss = _boss;
        enviroManager = _enviroManager;
    }

    public override void Enter()
    {
        player.stateMachine.ChangeState(player.playerGravState);
        boss.stateMachine.ChangeState(boss.bossSpongeState);
        enviroManager.stateMachine.ChangeState(enviroManager.enviroSpongeState);
    }

    public override void LogicUpdate()
    {
        player.stateMachine.currentState.LogicUpdate();
        boss.stateMachine.currentState.LogicUpdate();
        enviroManager.stateMachine.currentState.LogicUpdate();
    }
}
