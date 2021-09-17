using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    public StateMachine stateMachine;
    public EnvirSpongeState envirSpongeState;

    private float upperBound = 14.3f;
    private float lowerBound = 13.3f;

    public List<GameObject> launchPads;


    private void Awake()
    {
        envirSpongeState = new EnvirSpongeState();
        stateMachine = new StateMachine(envirSpongeState);
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
