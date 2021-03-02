using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCraftingRecipes : MonoBehaviour
{
    public GameObject recipeDisplay;
    public bool isopen;

    // Start is called before the first frame update
    void Start()
    {
        recipeDisplay.SetActive(false);    
    }

    public void OpenOrCloseRecipes()
    {
        if(isopen == false)
        {
            recipeDisplay.SetActive(true);
            isopen = true;
        }

        else if(isopen == true)
        {
            recipeDisplay.SetActive(false);
            isopen = false;
        }
    }
}
