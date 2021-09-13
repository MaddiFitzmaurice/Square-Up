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

    public override void Enter()
    {
        // Stop player's
        //player.playerMovement.ResetPlayerVelocity();
        player.playerMovement.GravEnter();
    }

    public override void LogicUpdate()
    {
        if (!GameManager.instance.gravOn)
        {
            player.stateMachine.ChangeState(player.playerNoGravState);
        }
        
        // ******Change input button later
        if (Input.GetKeyDown(KeyCode.P))
        {
            player.playerAttack.FireProjectile();
        }
    }

    // Maybe move the logic to playerMovement instead and use a player.playerMovement.Move() here
    public override void PhysicsUpdate()
    {
        player.playerMovement.GravMove();
    }

}
