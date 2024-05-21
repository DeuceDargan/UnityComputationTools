using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    StateMachineNode CurrentState => currentState;
    StateMachineNode currentState;

    protected bool inTransition;

    // Update is called once per frame
    void Update()
    {
        if (CurrentState != null && !inTransition)
        {
            CurrentState.Tick();
        }
    }

    public void ChangeState<T>() where T : StateMachineNode
    {
        T targetState = GetComponent<T>();

        if (targetState == null)
        {
            return;
        }
        
        InititeNewState(targetState);
    }

    public void InititeNewState(StateMachineNode targetState)
    {
        if (currentState != targetState && !inTransition)
        {
            CallNewState(targetState);
        }
    }

    void CallNewState(StateMachineNode newState)
    {
        inTransition = true;
        //
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
        //
        inTransition = false; 
    }
}
