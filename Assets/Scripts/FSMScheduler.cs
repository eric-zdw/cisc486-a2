using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMScheduler : MonoBehaviour
{
    GameObject[] fsmList;


    
    // Start is called before the first frame update
    void Start()
    {
        fsmList = GameObject.FindGameObjectsWithTag("FSM");
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject fsm in fsmList) {
            Renderer body = fsm.transform.Find("Body").GetComponent<Renderer>();
            FSM f = null;
            if (fsm.GetComponent<Villager>()) {
                f = fsm.GetComponent<Villager>().villagerFSM;
            }
            if (fsm.GetComponent<Enemy>()) {
                f = fsm.GetComponent<Enemy>().enemyFSM;
            }

            if (body.isVisible && f.GetPriority() != 1) {
                f.SetPriority(1);
                Debug.Log("set " + fsm.name + " to High");
            }
            else if (!body.isVisible && f.GetPriority() != 0) {
                f.SetPriority(0);
                Debug.Log("set " + fsm.name + " to Low");
            }
        }
    }
}
