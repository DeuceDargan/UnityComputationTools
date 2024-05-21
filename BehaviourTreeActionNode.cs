using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehaviourTreeActionNode : BehaviourTreeNode
{
    protected bool isActive;

    public bool IsActive()
    {
        return isActive;
    }

    public virtual void ActionComplete()
    {
        
    }
}
