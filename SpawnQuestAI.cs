using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnQuestAI : MonoBehaviour
{
    public GameObject[] questAI;
    GameObject currentQuestAI;
    public GameObject spawnPoint;
    public bool questIsActive = false;
    //public bool canMove = false;
    int index;
    //public GameObject playerObject;
    //public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
       // agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        index = Random.Range(0, questAI.Length);
        currentQuestAI = questAI[index];
        /*if(canMove == false)
        {
            
            canMove = true;
        }*/

        if(questIsActive == false)
        {
            Instantiate(currentQuestAI, spawnPoint.transform.position, spawnPoint.transform.rotation);
            //agent = questAI[index].GetComponent<NavMeshAgent>();
            //agent.SetDestination(playerObject.transform.position);
            questIsActive = true;
        }
    }
}
