using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Boss's state machine
    public StateMachine stateMachine;

    // Boss's states
    public BossSpongeState bossSpongeState;

    // Boss's movement
    public Rigidbody bossRb;

    // Player reference
    private Player player;

    private void Awake()
    {
        // Create link to boss components
        bossRb = GetComponent<Rigidbody>();

        // Create boss's states
        bossSpongeState = new BossSpongeState(this);

        // Create boss's state machine
        stateMachine = new StateMachine(bossSpongeState, player);

        // Get reference to player
        player = FindObjectOfType<Player>();
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
