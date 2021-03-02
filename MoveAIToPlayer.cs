using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAIToPlayer : MonoBehaviour
{
    public GameObject playerObject;
    public NavMeshAgent agent;
    public GameObject giveQuest;
    private GiveQuest takeQuest;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerObject = GameObject.Find("MainPlayer");
        giveQuest = GameObject.Find("_UI/Canvas");
        takeQuest = giveQuest.GetComponent<GiveQuest>();
    }

    // Update is called once per frame
    void Update()
    {
        if(takeQuest.questIsActive == false)
        {
            if(Vector3.Distance(playerObject.transform.position, this.transform.position) < 10 && Vector3.Distance(playerObject.transform.position, this.transform.position) >= 5)
            {
                agent.SetDestination(playerObject.transform.position);
                agent.isStopped = false;
            }

            else if(Vector3.Distance(playerObject.transform.position, this.transform.position) < 5)
            {
                agent.isStopped = true;
            }
        }

        else if(takeQuest.questIsActive == true)
        {
            agent.isStopped = true;
        }
    }
}
