using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAddQuest : MonoBehaviour
{
    private GiveQuest questObject;
    private MainQuestGiver mainQuestObject;
    private GameObject canvas;

    void Start()
    {
        canvas = GameObject.Find("_UI/Canvas");
        GiveQuest newCanvas = canvas.GetComponent<GiveQuest>();
        MainQuestGiver mainCanvas = canvas.GetComponent<MainQuestGiver>();
        mainQuestObject = mainCanvas;
        questObject = newCanvas;
    }

    public void GiveQuest()
    {
        questObject.ActivateVairiables();
    }

    public void RemoveQuest()
    {
        questObject.WantToRemove();
    }

    public void GiveMainQuest()
    {
        mainQuestObject.ActivateVairiables();
    }

    public void RemoveMainQuest()
    {
        mainQuestObject.WantToRemove();
    }
}
