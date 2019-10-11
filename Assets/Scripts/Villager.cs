using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Villager : MonoBehaviour {
    
    public int fruitsInInventory = 0;
    public int inventorySize = 2;
    public GameObject target;

    public float walkSpeed = 5f;

    FSM villagerFSM;
        
    void Start()
    {
        CreateFSM();
        Debug.Log("starting");
        StartCoroutine(villagerFSM.RunFSM());
    }

    void CreateFSM()
    {
        villagerFSM = new FSM(this);

        villagerFSM.AddState(new WalkToTreeNode());
        villagerFSM.AddState(new HarvestFruitNode());
        villagerFSM.AddState(new WalkToVillageNode());
    }

}
