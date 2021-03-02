using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PulsatingButtonQuit1 : EventTrigger
{
     private GameObject image;
    private GameObject arrow;
    Color lerpedColor = Color.white;
    Color lerpedColorArrow = Color.white;
    public bool enter = false;

    void Start()
    {
        image = GameObject.Find("_UI/Canvas/Pause_Panel/Quit");
        arrow = GameObject.Find("_UI/Canvas/Pause_Panel/Quit/Image");
    }

    void Update()
    {
        StartGlow();
    }

    public override void OnPointerEnter(PointerEventData data)
    {
        enter = true;
    }

    public override void OnPointerExit(PointerEventData data)
    {
        enter = false;
    }

    public void StartGlow()
    {  
        if(enter == true)
        {
            lerpedColor = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.unscaledTime/3, 1));
            image.GetComponent<Image>().color = lerpedColor;

            lerpedColorArrow = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.unscaledTime/3, 1));
            arrow.GetComponent<Image>().color = lerpedColor;
        }

        else if(enter == false)
        {
            image.GetComponent<Image>().color = Color.white;
            arrow.GetComponent<Image>().color = Color.white;
        }
    }
}
