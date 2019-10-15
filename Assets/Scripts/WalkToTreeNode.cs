using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToTreeNode : FSMNode
{
    Villager villagerData;

    Transform villagerTransform;
    private float waypointThreshold = 5f;

    public override void Entry()
    {
        villagerData = (Villager)GetAgent();
        villagerTransform = villagerData.transform;
        villagerData.target = FindClosestTree();
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
    }

    public override System.Type CheckTransition()
    {
        if (Vector3.Distance(villagerData.target.transform.position, villagerTransform.position) < waypointThreshold)
        {
            return typeof(HarvestFruitNode);
        }
        else
        {
            return null;
        }
    }

    private GameObject FindClosestTree()
    {
        GameObject[] trees = GameObject.FindGameObjectsWithTag("fruitTree");
        GameObject closestTree = null;
        float closestDistance = Mathf.Infinity;
        foreach (GameObject tree in trees)
        {
            if (!(tree.GetComponent<FruitTree>().GetFruitLeft() == 0))
            {
                float newDistance = Vector3.Distance(villagerTransform.position, tree.transform.position);
                if (newDistance < closestDistance)
                {
                    closestDistance = newDistance;
                    closestTree = tree;
                }
            }
        }

        return closestTree;
    }
}
