using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Create a singleton pattern
    public static GameManager instance { get; private set; }

    private Boss boss;
    private Player player;

    // Check if 'gravity' is on or off
    public bool gravOn;

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
        gravOn = true;

        // Get references to the player and boss
        player = FindObjectOfType<Player>();
        boss = FindObjectOfType<Boss>();

        boss.stateMachine.currentState.Enter();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gravOn = !gravOn;
        }

        
    }
}
