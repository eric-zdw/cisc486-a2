using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM
{
    private StartNode startNode;
    private FSMNode currentNode;
    private List<FSMNode> nodes;
    private MonoBehaviour agent;
    private int priority = 0;

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

        if (nodes.Count == 1)
        {
            Debug.Log(n.GetType());
            startNode.SetStartNode(n.GetType());
        }
    }

    public void SetStartState(System.Type n)
    {
        startNode.SetStartNode(n);
    }

    public IEnumerator RunFSM()
    {
        while (true)
        {
            currentNode.Do();
            System.Type transitionResult = currentNode.CheckTransition();
            if (transitionResult != null)
            {
                TransitionToNode(transitionResult);
            }

            if (priority == 1) yield return new WaitForEndOfFrame();
            else if (priority == 0) yield return new WaitForSeconds(1f);
        }
    }

    public MonoBehaviour GetAgent() { return agent; }

    public void SetPriority(int p) {
        priority = p;
    }

    public int GetPriority() {
        return priority;
    }

    public FSM(MonoBehaviour a)
    {
        currentNode = new StartNode();
        startNode = (StartNode)currentNode;
        nodes = new List<FSMNode>();
        agent = a;
    }
}
