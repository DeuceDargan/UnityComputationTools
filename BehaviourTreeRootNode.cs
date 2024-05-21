using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehaviourTreeRootNode : BehaviourTreeNode
{
    protected bool isActive;
    
    public virtual void GetActionState()
    {

    }

    public void SearchComplete()
    {
        isActive = false;
    }
}
