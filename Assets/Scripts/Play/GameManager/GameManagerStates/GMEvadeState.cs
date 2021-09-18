using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMEvadeState : BaseState
{
    private Player player;
    private Boss boss;
    private EnvironmentManager enviro;

    public GMEvadeState(Player _player, Boss _boss, EnvironmentManager _enviro)
    {
        player = _player;
        boss = _boss;
        enviro = _enviro;
    }

    public override void Enter()
    {
        player.stateMachine.ChangeState(player.playerNoGravState);
        //boss.
        enviro.stateMachine.ChangeState(enviro.enviroEvadeState);
    }
}
