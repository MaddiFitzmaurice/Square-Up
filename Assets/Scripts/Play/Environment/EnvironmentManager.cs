using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    public StateMachine stateMachine;
    public EnviroSpongeState enviroSpongeState;

    public List<GameObject> launchPads;


    private void Awake()
    {
        enviroSpongeState = new EnviroSpongeState();
        stateMachine = new StateMachine(enviroSpongeState);
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
