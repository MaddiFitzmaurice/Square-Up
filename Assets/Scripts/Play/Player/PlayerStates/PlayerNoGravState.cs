using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNoGravState : BaseState
{
    private Player player;
    public PlayerNoGravState(Player _player)
    {
        player = _player;
    }

    public override void LogicUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            player.stateMachine.ChangeState(player.playerGravState);
        }
    }
}
