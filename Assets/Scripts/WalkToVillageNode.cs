using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToVillageNode : FSMNode
{
    Villager villagerData;

    Transform villagerTransform;
    private float waypointThreshold = 10f;

    public override void Entry()
    {
        villagerData = (Villager)GetAgent();
        villagerTransform = villagerData.transform;
        villagerData.target = GameObject.FindGameObjectWithTag("village");
        villagerTransform.LookAt(villagerData.target.transform);
        villagerData.StartAnimation("Walk");

        villagerData.navMeshAgent.destination = villagerData.target.transform.position;
    }

    public override void Do()
    {

        //villagerTransform.position += Vector3.Normalize(villagerData.target.transform.position - villagerTransform.position) * villagerData.walkSpeed * Time.deltaTime;

    }

    public override void Exit()
    {
        villagerData.fruitsInInventory = 0;
    }

    public override System.Type CheckTransition()
    {
        if (Vector3.Distance(villagerData.target.transform.position, villagerTransform.position) < waypointThreshold)
        {
            return typeof(WalkToTreeNode);
        }
        else
        {
            return null;
        }
    }
}
