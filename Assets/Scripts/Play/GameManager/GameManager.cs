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

    // State machine
    public StateMachine gmStateMachine;
    public GMStartState gmStartState;
    public GMSpongeState gmSpongeState;
    public GMAttackState gmAttackState;


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
    }

    private void Start()
    {
        // Set up state machine and states
        gmStartState = new GMStartState(player, boss, enviro);
        gmSpongeState = new GMSpongeState(player, boss, enviro);
        gmAttackState = new GMAttackState(player, boss, enviro);
        gmStateMachine = new StateMachine(gmStartState);
        gmStateMachine.ChangeState(gmSpongeState);
    }

    private void Update()
    {
        
    }
}
