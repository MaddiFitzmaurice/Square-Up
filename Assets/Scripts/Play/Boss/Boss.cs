using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Boss's state machine
    public StateMachine stateMachine;

    // Boss's states
    public BossSpongeState bossSpongeState;
    public BossWeakState bossWeakState;

    // Boss's movement
    public BossMovement bossMovement;

    // Boss's movement
    public Rigidbody bossRb;

    // Player reference
    public Player player;

    private void Awake()
    {
        // Create link to boss components
        bossRb = GetComponent<Rigidbody>();
        bossMovement = GetComponent<BossMovement>();

        // Create boss's states
        bossSpongeState = new BossSpongeState(this);
        bossWeakState = new BossWeakState(this);

        // Create boss's state machine
        stateMachine = new StateMachine(bossSpongeState);

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
