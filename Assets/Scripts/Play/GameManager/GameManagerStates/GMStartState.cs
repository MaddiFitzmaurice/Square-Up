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
        boss.stateMachine.ChangeState(boss.bossWeakState);
    }

    public override void LogicUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Start here");
            GameManager.instance.gmStateMachine.ChangeState(GameManager.instance.gmSpongeState);
        }
    }
}
