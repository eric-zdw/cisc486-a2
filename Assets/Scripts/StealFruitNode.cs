using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealFruitNode : FSMNode
{
    Enemy enemyData;
    Villager targetVillager;

    private float timeInterval;
    private float timer;
    private float harvestInterval = 0.5f;
    private float waypointThreshold = 20f;

    public override void Entry()
    {
        enemyData = (Enemy)GetAgent();
        targetVillager = enemyData.target.GetComponent<Villager>();
        enemyData.StartAnimation("Pickup");
        timer = harvestInterval;
        timeInterval = Time.time;
    }

    public override void Do()
    {
        timeInterval = Time.time - timeInterval;
        int iterations = 0;

        timer -= timeInterval;
        while (timer <= 0f) {
            iterations++;
            timer += harvestInterval;
        }

        while (iterations != 0 && enemyData.fruitsInInventory != enemyData.inventorySize && targetVillager.fruitsInInventory != 0) {
            targetVillager.fruitsInInventory--;
            enemyData.fruitsInInventory++;
            iterations--;
        }

        timeInterval = Time.time;
    }

    public override void Exit()
    {
    }

    public override System.Type CheckTransition()
    {
        //Debug.Log(enemyData.fruitsInInventory + ", " + enemyData.inventorySize);
        if (enemyData.fruitsInInventory == enemyData.inventorySize)
        {
            return typeof(WalkToHideoutNode);
        }
        else if (targetVillager.fruitsInInventory == 0 || 
                    Vector3.Distance(enemyData.transform.position, targetVillager.transform.position) > waypointThreshold)
        {
            return typeof(WalkToVillagerNode);
        }
        else
        {
            return null;
        }
        
    }
}
