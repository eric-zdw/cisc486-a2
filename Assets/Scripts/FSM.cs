using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM
{
    FSMNode currentNode;

    private void Transition()
    {
        currentNode.Exit();
    }

    IEnumerator RunNode()
    {
        while (true)
        {
            currentNode.Do();
            if (currentNode.)
            yield return new WaitForSeconds(0.1f);
        }
    }

    void FSM()
    {

    }
}
