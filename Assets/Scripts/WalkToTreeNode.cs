using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToTreeNode : FSMNode
{
    public override void Entry()
    {
        Debug.Log("starting");
    }

    public override void Do()
    {
        Debug.Log("walking");
    }

    public override void Exit()
    {
        Debug.Log("leaving");
    }

    public WalkToTreeNode() : base()
    {
    
    }
}
