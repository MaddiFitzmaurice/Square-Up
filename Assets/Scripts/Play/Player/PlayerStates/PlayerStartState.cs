using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartState : BaseState
{
    private Player player;
    private Vector3 startPos = new Vector3(-11.8f, 0, -11.8f);

    public PlayerStartState(Player _player)
    {
        player = _player;
        player.transform.position = startPos;
    }

    public override void Enter()
    {
        player.playerMovement.MoveToStartPos();
    }
}
