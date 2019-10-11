using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNode : FSMNode
{
    System.Type transition;

    public override void Entry()
    {
    }

    public override void Do()
    {
    }

    public override void Exit()
    {
    }

    public override System.Type CheckTransition()
    {
        return transition;
    }

    public void SetStartNode(System.Type nodeType)
    {
        transition = nodeType;
    }

    public StartNode() : base()
    {
        transition = null;
    }

    public StartNode(System.Type nodeType) : base()
    {
        transition = nodeType;
    }
}
