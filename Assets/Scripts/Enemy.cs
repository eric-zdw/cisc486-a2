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

    FSM enemyFSM;
    public NavMeshAgent navMeshAgent;
        
    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        CreateFSM();
        Debug.Log("starting");
        StartCoroutine(enemyFSM.RunFSM());
    }

    void CreateFSM()
    {
        enemyFSM = new FSM(this);

        enemyFSM.AddState(new WalkToVillagerNode());
        enemyFSM.AddState(new StealFruitNode());
        enemyFSM.AddState(new WalkToHideoutNode());
    }

    public void StartAnimation(string s) {
        animator.SetTrigger(Animator.StringToHash(s));
    }

}
