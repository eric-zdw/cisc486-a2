using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToHideoutNode : FSMNode
{
    Enemy enemyData;

    Transform enemyTransform;
    private float waypointThreshold = 10f;

    public override void Entry()
    {
        enemyData = (Enemy)GetAgent();
        enemyTransform = enemyData.transform;
        enemyData.target = GameObject.FindGameObjectWithTag("hideout");
        enemyData.StartAnimation("Walk");

        enemyData.navMeshAgent.destination = enemyData.target.transform.position;
    }

    public override void Do()
    {

        //enemyTransform.position += Vector3.Normalize(enemyData.target.transform.position - enemyTransform.position) * enemyData.walkSpeed * Time.deltaTime;

    }

    public override void Exit()
    {
        enemyData.fruitsInInventory = 0;
    }

    public override System.Type CheckTransition()
    {
        if (Vector3.Distance(enemyData.target.transform.position, enemyTransform.position) < waypointThreshold)
        {
            return typeof(WalkToVillagerNode);
        }
        else
        {
            return null;
        }
    }
}
