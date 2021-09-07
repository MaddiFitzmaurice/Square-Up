using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class StateMachine
{
    public BaseState currentState { get; private set; }

    public StateMachine(BaseState _startingState)
    {
        currentState = _startingState;
        //currentState.Enter();
    }

    public void ChangeState(BaseState _stateName)
    {
        //Need to ensure stateName exists
        Assert.IsNotNull(_stateName);
        currentState.Exit();
        currentState = _stateName;
        currentState.Enter();
    }
}