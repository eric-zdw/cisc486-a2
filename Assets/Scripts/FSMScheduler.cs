using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMScheduler : MonoBehaviour
{
    GameObject[] fsmList;
    List<FSM> highPriorityList;
    List<FSM> lowPriorityList;
    
    // Start is called before the first frame update
    void Start()
    {
        fsmList = GameObject.FindGameObjectsWithTag("FSM");
        highPriorityList = new List<FSM>();
        lowPriorityList = new List<FSM>();

        StartCoroutine(HighPriorityFSM());
        StartCoroutine(LowPriorityFSM());
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

            if (body.isVisible && !highPriorityList.Contains(f)) {
                lowPriorityList.Remove(f);
                highPriorityList.Add(f);
                Debug.Log("set " + fsm.name + " to High");
            }
            else if (!body.isVisible && !lowPriorityList.Contains(f)) {
                highPriorityList.Remove(f);
                lowPriorityList.Add(f);
                Debug.Log("set " + fsm.name + " to Low");
            }
        }
    }

    private IEnumerator HighPriorityFSM() {
        while (true) {
            foreach (FSM fsm in highPriorityList) {
                fsm.RunFSM();
            }
            yield return null;
        }
    }

    private IEnumerator LowPriorityFSM() {
        while (true) {
            foreach (FSM fsm in lowPriorityList) {
                fsm.RunFSM();
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
