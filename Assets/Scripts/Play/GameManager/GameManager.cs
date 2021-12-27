using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /* Create a singleton pattern so every system's state
    // is controlled from a single point and systems can
    influence state changes for other systems */

    public static GameManager instance { get; private set; }

    private Boss boss;
    private Player player;
    private EnvironmentManager enviro;
    private GameUI gameUI;

    public GameData gameData;

    // State machine
    public StateMachine gmStateMachine;
    public GMStartState gmStartState;
    public GMEvadeState gmEvadeState;
    public GMSpongeState gmSpongeState;
    public GMAttackState gmAttackState;
    public GMEndState gmEndState;

    private void Awake()
    {
        // Set up singleton pattern
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }

        // Get references to systems
        player = FindObjectOfType<Player>();
        boss = FindObjectOfType<Boss>();
        enviro = FindObjectOfType<EnvironmentManager>();
        gameUI = FindObjectOfType<GameUI>();

        // Get data reference
        gameData = GetComponent<GameData>();
    }

    private void Start()
    {
        // Set up state machine and states
        gmStartState = new GMStartState(player, boss, enviro, gameUI);
        gmEvadeState = new GMEvadeState(player, boss, enviro, gameUI);
        gmSpongeState = new GMSpongeState(player, boss, enviro, gameUI);
        gmAttackState = new GMAttackState(player, boss, enviro, gameUI);
        gmEndState = new GMEndState(player, boss, enviro, gameUI);

        gmStateMachine = new StateMachine(gmStartState);
        gmStateMachine.ChangeState(gmStartState);
    }

    private void Update()
    {
        gmStateMachine.currentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        gmStateMachine.currentState.PhysicsUpdate();
    }
}
