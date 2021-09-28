using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : BaseState
{
    private Player player;

    public PlayerAttackState(Player _player)
    {
        player = _player;
    }

    public override void Enter()
    {

    }

    public override void LogicUpdate()
    {

    }

    public override void PhysicsUpdate()
    {
        player.playerMovement.GravMove();
    }

    public override void Exit()
    {
        player.playerAttack.hasDoneBigAttack = false;
    }
}
