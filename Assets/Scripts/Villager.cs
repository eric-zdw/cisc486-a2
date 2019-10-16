using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Villager : MonoBehaviour {

    private Animator animator;
    private int currentAnimationHash;
    public int fruitsInInventory = 0;
    public int inventorySize = 10;
    public GameObject target;

    public float walkSpeed = 4f;

    public FSM villagerFSM;
    public NavMeshAgent navMeshAgent;
        
    void Start()
    {
        currentAnimationHash = Animator.StringToHash("Idle");
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        CreateFSM();
    }

    void CreateFSM()
    {
        villagerFSM = new FSM(this);

        villagerFSM.AddState(new WalkToTreeNode());
        villagerFSM.AddState(new HarvestFruitNode());
        villagerFSM.AddState(new WalkToVillageNode());
        villagerFSM.AddState(new DropOffFruitNode());
    }

    public void StartAnimation(string s) {
        animator.ResetTrigger(currentAnimationHash);
        currentAnimationHash = Animator.StringToHash(s);
        animator.SetTrigger(Animator.StringToHash(s));
    }

}
