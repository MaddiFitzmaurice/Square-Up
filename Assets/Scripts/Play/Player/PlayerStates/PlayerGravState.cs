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
        
    }

    public override void PhysicsUpdate()
    {
        if (player.playerMovement.FloorCeilingCheck())
        {
            player.playerRb.velocity = new Vector3(player.playerMovement.horizontalInput * player.playerData.gravSpeed, 0, player.playerRb.velocity.z);
        }
        if (player.playerMovement.WallCheck())
        {
            player.playerRb.velocity = new Vector3(player.playerRb.velocity.x, 0, player.playerMovement.verticalInput * player.playerData.gravSpeed);
        }
    }

}
