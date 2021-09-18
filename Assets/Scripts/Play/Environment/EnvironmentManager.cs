using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum LaunchpadDir { Floor, Ceiling, Left, Right };

public class EnvironmentManager : MonoBehaviour
{
    // State machine and states
    public StateMachine stateMachine;
    public EnviroSpongeState enviroSpongeState;
    public EnviroLaunchState enviroLaunchState;

    public List<LaunchpadMovement> launchPads;


    private void Awake()
    {
        // State machine setup
        enviroSpongeState = new EnviroSpongeState(this);
        enviroLaunchState = new EnviroLaunchState(this);
        stateMachine = new StateMachine(enviroSpongeState);
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
