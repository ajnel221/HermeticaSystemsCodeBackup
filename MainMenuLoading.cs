using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuLoading : MonoBehaviour
{
    public static MainMenuLoading instance;
    public bool loadSaveData = false;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        else if(instance != this)
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);
    }

    public void ClickLoad()
    {
        loadSaveData = true;
    }
}
