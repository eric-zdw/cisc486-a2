using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestFruitNode : FSMNode
{
    Villager villagerData;
    FruitTree targetTree;

    private float timeInterval;
    private float timer;
    public float harvestInterval = 1f;

    public override void Entry()
    {
        villagerData = (Villager)GetAgent();
        targetTree = villagerData.target.GetComponent<FruitTree>();
        villagerData.StartAnimation("Pickup");
        timer = harvestInterval;
        timeInterval = Time.time;
    }

    public override void Do()
    {
        timeInterval = Time.time - timeInterval;
        //Debug.Log(timeInterval);

        timer -= timeInterval;
        while (timer <= 0f) {
            GetFruit(targetTree);
            timer += harvestInterval;
        }

        timeInterval = Time.time;
    }

    public override void Exit()
    {
    }

    public override System.Type CheckTransition()
    {
        if (villagerData.fruitsInInventory == villagerData.inventorySize)
        {
            return typeof(WalkToVillageNode);
        }
        else if (targetTree.GetFruitLeft() == 0)
        {
            return typeof(WalkToTreeNode);
        }
        else
        {
            return null;
        }
        
    }

    private void GetFruit(FruitTree t)
    {
        t.TakeFruit();
        villagerData.fruitsInInventory += 1;
    }
}
