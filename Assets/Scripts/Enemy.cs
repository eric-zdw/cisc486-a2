using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour {

    private Animator animator;

    public int fruitsInInventory = 0;
    public int inventorySize = 3;
    public GameObject target;

    public float walkSpeed = 10f;

    public FSM enemyFSM;
    public NavMeshAgent navMeshAgent;

    private int currentAnimationHash;
        
    void Start()
    {
        currentAnimationHash = Animator.StringToHash("Idle");
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        CreateFSM();
    }

    void CreateFSM()
    {
        enemyFSM = new FSM(this);

        enemyFSM.AddState(new WalkToVillagerNode());
        enemyFSM.AddState(new StealFruitNode());
        enemyFSM.AddState(new WalkToHideoutNode());
    }

    public void StartAnimation(string s) {
        animator.ResetTrigger(currentAnimationHash);
        currentAnimationHash = Animator.StringToHash(s);
        animator.SetTrigger(Animator.StringToHash(s));
    }

}
