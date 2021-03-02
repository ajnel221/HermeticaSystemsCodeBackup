using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveLootIndicator : MonoBehaviour
{
    public GameObject lootIndicator;
    public float timeBeforeIndicatorDies;
    private float time;

    public void Start()
    {
        time = timeBeforeIndicatorDies;
    }

    public void Update()
    {
        if(time > 0)
        {
            time = time - Time.deltaTime;
        }

        else if(time <= 0)
        {
            lootIndicator.SetActive(false);
        }
    }
}