using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestFruitNode : FSMNode
{
    Villager villagerData;
    FruitTree targetTree;

    public override void Entry()
    {
        villagerData = (Villager)GetAgent();
        targetTree = villagerData.target.GetComponent<FruitTree>();
    }

    public override void Do()
    {
        if (targetTree.GetFruitLeft() > 0)
        {
            GetFruit(targetTree);
        }
    }

    public override void Exit()
    {
    }

    public override System.Type CheckTransition()
    {
        Debug.Log(targetTree.GetFruitLeft());
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
