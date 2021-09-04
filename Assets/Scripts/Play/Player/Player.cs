using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Player's state machine
    public StateMachine stateMachine;

    // Player's states
    public PlayerGravState playerGravState;

    // Player movement
    public PlayerMovement playerMovement;
    public Rigidbody playerRb;
    public PlayerData playerData;

    private void Awake()
    {
        // Create link to player components
        playerMovement = GetComponent<PlayerMovement>();
        playerRb = GetComponent<Rigidbody>();
        playerData = GetComponent<PlayerData>();

        // Create player's states
        playerGravState = new PlayerGravState(this);
        // playerNoGravState = new PlayerNoGravState(this);

        // Create player's state machine
        stateMachine = new StateMachine(playerGravState);
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }
}
