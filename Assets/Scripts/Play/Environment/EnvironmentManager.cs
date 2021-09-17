using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    public StateMachine stateMachine;
    public EnviroSpongeState enviroSpongeState;

    public List<GameObject> launchPads;

    public enum LaunchpadDir { floor, ceiling, left, right};

    private void Awake()
    {
        enviroSpongeState = new EnviroSpongeState(this, launchPads);
        stateMachine = new StateMachine(enviroSpongeState);
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
