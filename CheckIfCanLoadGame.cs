using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CheckIfCanLoadGame : MonoBehaviour
{
    public GameObject loadButton;

    void Update()
    {
        LoadGame();
    }

    public void LoadGame()
    {
        if(!File.Exists(Application.persistentDataPath + "/Game_Save/Character_Data/InventoryData.txt"))
        {
            loadButton.GetComponent<Button>().interactable = false;
        }

        else if(File.Exists(Application.persistentDataPath + "/Game_Save/Character_Data/InventoryData.txt"))
        {
            loadButton.GetComponent<Button>().interactable = true;
        }
    }
}
