using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpongeState : BaseState
{
    private Player player;
    private Boss boss;

    public BossSpongeState(Boss _boss, Player _player)
    {
        boss = _boss;
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
        
    }
}
