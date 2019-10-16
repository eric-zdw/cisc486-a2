using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOffFruitNode : FSMNode
{
    Villager villagerData;
    FruitTree targetTree;

    private float timeInterval;
    private float timer;
    public float dropOffInterval = 4f;

    public override void Entry()
    {
        villagerData = (Villager)GetAgent();
        targetTree = villagerData.target.GetComponent<FruitTree>();
        villagerData.StartAnimation("Drop");
        timer = dropOffInterval;
        timeInterval = Time.time;
    }

    public override void Do()
    {
        timeInterval = Time.time - timeInterval;
        timer -= timeInterval;
        timeInterval = Time.time;
    }

    public override void Exit()
    {
    }

    public override System.Type CheckTransition()
    {
        if (timer <= 0f) {
            return typeof(WalkToTreeNode);
        }
        else {
            return null;
        }
    }
    
    private void GetFruit(FruitTree t)
    {
        t.TakeFruit();
        villagerData.fruitsInInventory += 1;
    }
}
