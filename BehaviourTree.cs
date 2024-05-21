using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class BehaviourTree : MonoBehaviour
{
    BehaviourTreeActionNode currentState;
    public BehaviourTreeActionNode CurrentState => currentState;
    Queue<BehaviourTreeActionNode> queuedStates = new Queue<BehaviourTreeActionNode>();
    BehaviourTreeRootNode rootNode;

    protected bool inTransition;

    private void Awake()
    {
        rootNode = GetComponent<BehaviourTreeRootNode>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (CurrentState == null || !currentState.IsActive())
        {
            NextState();
        }

        if (CurrentState != null && !inTransition)
        {
            CurrentState.Tick();
        }
    }

    public void ChangeState<T>() where T : BehaviourTreeActionNode
    {
        T targetState = GetComponent<T>();

        if (targetState == null)
        {
            return;
        }
        
        InititeNewState(targetState);
    }

    public void InititeNewState(BehaviourTreeActionNode targetState)
    {
        if (!inTransition)
        {
            CallNewState(targetState);
        }
    }

    void CallNewState(BehaviourTreeActionNode newState)
    {
        inTransition = true;
        //
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
        //
        inTransition = false; 
    }

    public void InteruptList()
    {
        queuedStates = new Queue<BehaviourTreeActionNode>();
    }

    public void AddAction (BehaviourTreeActionNode action)
    {
        queuedStates.Enqueue(action);
    }

    public void SearchComplete()
    {
        rootNode.SearchComplete();
    }

    public void NextState()
    {
        if (queuedStates.Count > 0)
        {
            InititeNewState(queuedStates.Dequeue());
        }
        else
        {
            rootNode.GetActionState();
        }
    }

    public void EndCurrentAction()
    {
        currentState.ActionComplete();
    }

    public void ForceAction(BehaviourTreeActionNode newState)
    {
        CallNewState(newState);
        queuedStates = new Queue<BehaviourTreeActionNode>();
    }
}
