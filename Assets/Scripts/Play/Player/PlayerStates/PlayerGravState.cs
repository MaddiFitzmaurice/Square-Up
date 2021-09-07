using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerGravState : BaseState
{
    private Player player;

    public PlayerGravState(Player _player)
    {
        player = _player;
    }

    public override void LogicUpdate()
    {
        if (!GameManager.instance.gravOn)
        {
            player.stateMachine.ChangeState(player.playerNoGravState);
        }    
    }

    public override void PhysicsUpdate()
    {
        if (player.playerMovement.CeilingCheck() || player.playerMovement.FloorCheck())
        {
            player.playerRb.velocity = new Vector3(player.playerMovement.horizontalInput * player.playerData.gravSpeed, 0, player.playerRb.velocity.z);
        }

        if (player.playerMovement.RightWallCheck() || player.playerMovement.LeftWallCheck())
        {
            player.playerRb.velocity = new Vector3(player.playerRb.velocity.x, 0, player.playerMovement.verticalInput * player.playerData.gravSpeed);
        }
    }

}
