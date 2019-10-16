using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToVillagerNode : FSMNode
{
    Enemy enemyData;

    Transform enemyTransform;
    private float waypointThreshold = 5f;

    public override void Entry()
    {
        enemyData = (Enemy)GetAgent();
        enemyTransform = enemyData.transform;
        enemyData.target = FindClosestVillager();
        enemyData.StartAnimation("Walk");

        enemyData.navMeshAgent.destination = enemyData.target.transform.position;
    }

    public override void Do()
    {
        enemyData.navMeshAgent.destination = enemyData.target.transform.position;
        //enemyTransform.position += Vector3.Normalize(enemyData.target.transform.position - enemyTransform.position) * enemyData.walkSpeed * Time.deltaTime;

    }

    public override void Exit()
    {
    }

    public override System.Type CheckTransition()
    {
        //Debug.Log(Vector3.Distance(enemyData.target.transform.position, enemyTransform.position));
        if (Vector3.Distance(enemyData.target.transform.position, enemyTransform.position) < waypointThreshold)
        {
            Debug.Log("stealing!");
            return typeof(StealFruitNode);
        }
        else
        {
            return null;
        }
    }

    
    private GameObject FindClosestVillager()
    {
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("FSM");
        List<GameObject> villagers = new List<GameObject>();
        foreach (GameObject npc in npcs) {
            if (npc.GetComponent<Villager>() && npc != enemyData.target) {
                villagers.Add(npc);
            }
        }

        GameObject closestVillager = null;
        float closestDistance = Mathf.Infinity;
        foreach (GameObject villager in villagers)
        {
            float newDistance = Vector3.Distance(enemyTransform.position, villager.transform.position);
            if (newDistance < closestDistance)
            {
                closestDistance = newDistance;
                closestVillager = villager;
            }
        }

        return closestVillager;
    }
}
