using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMNode
{
    protected string nodeName;
    protected List<string> transitionList;

    public void AddTransition(string node)
    {
        transitionList.Add(node);
    }

    public abstract void Entry();

    public abstract void Do();

    public abstract void Exit();

    public FSMNode()
    {
        nodeName = null;
        transitionList = new List<string>();
    }
}
