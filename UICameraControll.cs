using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICameraControll : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject headPos;
    public GameObject chestPos;
    public GameObject fullBodyPos;
    public GameObject legsPos;
    public GameObject feetPos;
    public RectTransform headRect;
    public RectTransform chestRect;
    public RectTransform legsRect;
    public RectTransform feetRect;
    public bool isViewingHead = false;
    public bool isViewingChest = false;
    public bool isViewingLegs = false;
    public bool isViewingFeet = false;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera.transform.position = fullBodyPos.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ViewHead()
    {
        if(isViewingHead == false)
        {
            mainCamera.transform.position = headPos.transform.position;
            isViewingHead = true;
            isViewingChest = false;
            isViewingLegs = false;
            isViewingFeet = false;

            headRect.localScale = new Vector3(3.5f , 7, 1);
            headRect.localPosition = new Vector3(-2, -5.5f, 0);
            chestRect.localScale = new Vector3(0,0,0);
            legsRect.localScale = new Vector3(0,0,0);
            feetRect.localScale = new Vector3(0,0,0);
        }

        else if(isViewingHead == true)
        {
            mainCamera.transform.position = fullBodyPos.transform.position;  
            isViewingHead = false;
            isViewingChest = false;
            isViewingLegs = false;
            isViewingFeet = false;

            headRect.localScale = new Vector3(1, 1, 1);
            headRect.localPosition = new Vector3(-8.9f, 172, 0);
            chestRect.localScale = new Vector3(1,1,1);
            legsRect.localScale = new Vector3(1,1,1);
            feetRect.localScale = new Vector3(1,1,1);
        }
    }

    public void ViewChest()
    {
        if(isViewingChest == false)
        {
            mainCamera.transform.position = chestPos.transform.position;
            isViewingChest = true;
            isViewingHead = false;
            isViewingLegs = false;
            isViewingFeet = false;

            chestRect.localScale = new Vector3(2.5f , 4, 1);
            headRect.localScale = new Vector3(0,0,0);
            legsRect.localScale = new Vector3(0,0,0);
            feetRect.localScale = new Vector3(0,0,0);
        }

        else if(isViewingChest == true)
        {
            mainCamera.transform.position = fullBodyPos.transform.position;  
            isViewingChest = false;
            isViewingHead = false;
            isViewingLegs = false;
            isViewingFeet = false;

            chestRect.localScale = new Vector3(1,1,1);
            legsRect.localScale = new Vector3(1,1,1);
            headRect.localScale = new Vector3(1,1,1);
            feetRect.localScale = new Vector3(1,1,1);
        }
    }

    public void ViewLegs()
    {
        if(isViewingLegs == false)
        {
            mainCamera.transform.position = legsPos.transform.position;
            isViewingLegs = true;
            isViewingHead = false;
            isViewingChest = false;
            isViewingFeet = false;

            legsRect.localScale = new Vector3(2.5f , 4, 1);
            headRect.localScale = new Vector3(0,0,0);
            chestRect.localScale = new Vector3(0,0,0);
            feetRect.localScale = new Vector3(0,0,0);
        }

        else if(isViewingLegs == true)
        {
            mainCamera.transform.position = fullBodyPos.transform.position;  
            isViewingLegs = false;
            isViewingHead = false;
            isViewingChest = false;
            isViewingFeet = false;

            legsRect.localScale = new Vector3(1,1,1);
            headRect.localScale = new Vector3(1,1,1);
            chestRect.localScale = new Vector3(1,1,1);
            feetRect.localScale = new Vector3(1,1,1);
        }
    }

    public void ViewFeet()
    {
        if(isViewingFeet == false)
        {
            mainCamera.transform.position = feetPos.transform.position;
            isViewingFeet = true;
            isViewingHead = false;
            isViewingChest = false;
            isViewingLegs = false;

            feetRect.localScale = new Vector3(2.5f , 3.5f, 1);
            feetRect.localPosition = new Vector3(-4.2f, 42, 0);
            headRect.localScale = new Vector3(0,0,0);
            chestRect.localScale = new Vector3(0,0,0);
            legsRect.localScale = new Vector3(0,0,0);
        }

        else if(isViewingFeet == true)
        {
            mainCamera.transform.position = fullBodyPos.transform.position;  
            isViewingFeet = false;
            isViewingHead = false;
            isViewingChest = false;
            isViewingLegs = false;

            feetRect.localScale = new Vector3(1,1,1);
            feetRect.localPosition = new Vector3(-8.9f, -180.05f, 0);
            legsRect.localScale = new Vector3(1,1,1);
            headRect.localScale = new Vector3(1,1,1);
            chestRect.localScale = new Vector3(1,1,1);
        }
    }
}
