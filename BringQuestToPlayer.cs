using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringQuestToPlayer : MonoBehaviour
{
    private GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        panel = GameObject.Find("_UI/Canvas/Panel");
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            panel.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            panel.SetActive(false);
        }
    }
}
