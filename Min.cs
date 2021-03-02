using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Min : MonoBehaviour
{
    public RectTransform transformTest;
    public RectTransform transformTest1;
    public RectTransform holderTransform;
    public RectTransform map;
    public bool isOpen = false;
    public bool mapIsOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        transformTest.localScale = new Vector3 (0,0,0);
        transformTest1.localScale = new Vector3 (0,0,0);
        holderTransform.localScale = new Vector3 (0,0,0);
        map.localScale = new Vector3 (0,0,0);
    }

     void Update()
    {
        if(Input.GetKeyDown(KeyCode.I) && isOpen == false)
        {
            isOpen = true;
            holderTransform.localScale = new Vector3(1,1,1);
            transformTest.localScale = new Vector3 (1,1,1);
            transformTest1.localScale = new Vector3 (1,1,1);
        }

        else if(Input.GetKeyDown(KeyCode.I) && isOpen == true)
        {
            isOpen = false;
            holderTransform.localScale = new Vector3 (0,0,0);
            transformTest.localScale = new Vector3 (0,0,0);
            transformTest1.localScale = new Vector3 (0,0,0);
        }

        else if(Input.GetKeyDown(KeyCode.M) && mapIsOpen == false)
        {
            mapIsOpen = true;
            map.localScale = new Vector3 (1,1,1);
        }

        else if(Input.GetKeyDown(KeyCode.M) && mapIsOpen == true)
        {
            mapIsOpen = false;
            map.localScale = new Vector3 (0,0,0);
        }
    }
}
