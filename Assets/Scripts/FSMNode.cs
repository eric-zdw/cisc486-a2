using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMNode
{
    protected FSM fsm;

    public abstract System.Type CheckTransition();

    public abstract void Entry();

    public abstract void Do();

    public abstract void Exit();

    public MonoBehaviour GetAgent() { return fsm.GetAgent(); }

    public void SetFSM(FSM f) { fsm = f; }

    public FSMNode()
    {
    }
}
