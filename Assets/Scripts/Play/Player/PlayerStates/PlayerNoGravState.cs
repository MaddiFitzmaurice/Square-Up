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

    public override void Enter()
    {
        // Stop player's momentum
        player.playerMovement.ResetPlayerVelocity();
        player.playerMovement.NoGravEnter();
    }

    public override void LogicUpdate()
    {
        // Change state here?
    }

    public override void PhysicsUpdate()
    {
        player.playerMovement.NoGravMove();
    }

    public override void Exit()
    {
        player.playerMovement.GravEnter();
    }
}
