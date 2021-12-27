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
        
    }

    public override void LogicUpdate()
    {   
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

    public override void PhysicsUpdate()
    {
        player.playerMovement.GravMove();
    }

}
