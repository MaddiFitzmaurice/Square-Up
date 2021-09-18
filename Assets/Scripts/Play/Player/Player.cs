using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Player's state machine
    public StateMachine stateMachine;

    // Player's states
    public PlayerStartState playerStartState;
    public PlayerGravState playerGravState;
    public PlayerNoGravState playerNoGravState;

    // Player components
    public PlayerAttack playerAttack;
    public PlayerMovement playerMovement;
    public Rigidbody playerRb;
    public PlayerData playerData;

    private void Awake()
    {
        // Create link to player components
        playerRb = GetComponent<Rigidbody>();
        playerData = GetComponent<PlayerData>();
        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponent<PlayerAttack>();

        // Create player's states
        playerStartState = new PlayerStartState(this);
        playerGravState = new PlayerGravState(this);
        playerNoGravState = new PlayerNoGravState(this);

        // Create player's state machine
        stateMachine = new StateMachine(playerStartState);
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
