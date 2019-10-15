using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Villager : MonoBehaviour {

    private Animator animator;

    private int walkHash = Animator.StringToHash("Walk");
    private int idleHash = Animator.StringToHash("Idle");
    private int dropHash = Animator.StringToHash("Drop");
    private int pickHash = Animator.StringToHash("Pickup");

    private int idleStateHash = Animator.StringToHash("idle");
    private int walkingStateHash = Animator.StringToHash("walking");
    private int dropStateHash = Animator.StringToHash("dropping");
    private int pickupStateHash = Animator.StringToHash("pickingFruit");

    public int fruitsInInventory = 0;
    public int inventorySize = 10;
    public GameObject target;

    public float walkSpeed = 4f;

    public FSM villagerFSM;
    public NavMeshAgent navMeshAgent;
        
    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
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

    public void StartAnimation(string s) {
        animator.SetTrigger(Animator.StringToHash(s));
    }

}
