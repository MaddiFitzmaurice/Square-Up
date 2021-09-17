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
        
    }

    public override void LogicUpdate()
    {   
        // ******Change input button later
        if (Input.GetKeyDown(KeyCode.P))
        {
            player.playerAttack.FireProjectile();
        }

        if (player.playerData.health == 0)
        {
            Debug.Log("You died.");
            // GameManager.instance.gmStateMachine.ChangeState(GameManager.instance.gmEndState);
        }
    }

    // Maybe move the logic to playerMovement instead and use a player.playerMovement.Move() here
    public override void PhysicsUpdate()
    {
        player.playerMovement.GravMove();
    }

}
