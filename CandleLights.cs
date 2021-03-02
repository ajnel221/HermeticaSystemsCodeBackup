using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleLights : MonoBehaviour
{
    public Light lt;
    public float range1;
    public float range2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lt.intensity = Random.Range(range1, range2);
    }
}
