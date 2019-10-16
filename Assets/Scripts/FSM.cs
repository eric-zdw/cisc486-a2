using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM
{
    private StartNode startNode;
    private FSMNode currentNode;
    private List<FSMNode> nodes;
    private MonoBehaviour agent;

    private void TransitionToNode(System.Type t)
    {
        currentNode.Exit();

        foreach (FSMNode node in nodes)
        {
            if (node.GetType() == t)
            {
                currentNode = node;
                break;
            }
        }

        currentNode.Entry();
    }

    public void AddState(FSMNode n)
    {
        n.SetFSM(this);
        nodes.Add(n);

        //if this node is the first one, set as start node
        if (nodes.Count == 1)
        {
            startNode.SetStartNode(n.GetType());
        }
    }

    public void SetStartState(System.Type n)
    {
        startNode.SetStartNode(n);
    }

    public void RunFSM()
    {   
        currentNode.Do();
        System.Type transitionResult = currentNode.CheckTransition();
        if (transitionResult != null)
        {
            TransitionToNode(transitionResult);
        }
    }

    public MonoBehaviour GetAgent() { return agent; }

    public FSM(MonoBehaviour a)
    {
        currentNode = new StartNode();
        startNode = (StartNode)currentNode;
        nodes = new List<FSMNode>();
        agent = a;
    }
}
