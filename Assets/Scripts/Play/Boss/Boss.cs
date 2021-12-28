using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Boss's state machine
    public StateMachine stateMachine;

    // Boss's states
    public BossStartState bossStartState;
    public BossNoGravState bossNoGravState;
    public BossSpongeState bossSpongeState;
    public BossWeakState bossWeakState;
    public BossEndState bossEndState;

    // Boss's components
    public BossMovement bossMovement;
    public Rigidbody bossRb;
    public BossAttacks bossAttacks;
    public BossData bossData;
    public BossHealthManager bossHealthManager;

    // Player reference
    public Player player;

    private void Awake()
    {
        // Create link to boss components
        bossRb = GetComponent<Rigidbody>();
        bossMovement = GetComponent<BossMovement>();
        bossAttacks = GetComponent<BossAttacks>();
        bossData = GetComponent<BossData>();
        bossHealthManager = GetComponent<BossHealthManager>();

        // Create boss's states
        bossStartState = new BossStartState(this);
        bossNoGravState = new BossNoGravState(this);
        bossSpongeState = new BossSpongeState(this);
        bossWeakState = new BossWeakState(this);
        bossEndState = new BossEndState(this);

        // Create boss's state machine
        stateMachine = new StateMachine(bossStartState);

        // Get reference to player
        player = FindObjectOfType<Player>();
    }

    private void Start()
    {

    }
}
