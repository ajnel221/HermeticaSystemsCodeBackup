using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseOptions : MonoBehaviour
{
    public GameObject optionsOpen;

    // Start is called before the first frame update
    void Start()
    {
        optionsOpen.SetActive(false);
    }

    public void OpenOptions()
    {
        optionsOpen.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsOpen.SetActive(false);
    }
}
