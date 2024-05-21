using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectBlackBoard : MonoBehaviour
{
    protected BehaviourTree behaviourTree;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void ForceAction(BehaviourTreeActionNode action)
    {
        behaviourTree.ForceAction(action);
    }
}