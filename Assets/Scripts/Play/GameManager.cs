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

    // Key flags for influencing systems
    public bool start = true;
    public bool sponge = false;
    public bool evade = false;
    public bool attack = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }
    }

    private void Start()
    {
        sponge = true;

        // Get references to the player and boss
        player = FindObjectOfType<Player>();
        boss = FindObjectOfType<Boss>();

        boss.stateMachine.currentState.Enter();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sponge = !sponge;
        }

        
    }
}
