using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;
using System.Runtime.Serialization;
using UnityEngine.UI;

public class TestCrafting : MonoBehaviour
{
    public InventoryObject inventory;
    public NewBehaviourScript craftingRecipeNew;
    public InventoryObject craftingTable;
    public GameObject craftingMenu;
    public RectTransform inventoryMenu;
    public bool menuIsOpen = false;
    public GameObject craftButton;
    public GameObject craftButton2;
    public bool craftingOutput1 = false;
    public bool craftingOutput2 = false;

    void Start() 
    {
        craftButton.SetActive(false);
        craftButton2.SetActive(false);
    }

    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.C))
        {
            if(menuIsOpen == false)
            {
                craftingMenu.SetActive(true);
                inventoryMenu.localScale = new Vector3 (0,0,0);
                menuIsOpen = true;
            }

            else if(menuIsOpen == true)
            {
                craftingMenu.SetActive(false);
                inventoryMenu.localScale = new Vector3 (0,0,0);
                menuIsOpen = false;
            }
        }*/

        CanCraft();
    }

    public void CanCraft()
    {
        CraftRecipe1();
        CraftRecipe2();
    }

    public void CraftRecipe1()
    {
        if((craftingRecipeNew.craftingRecipesNew[0].itemObject[0].Id == craftingTable.Container.Slots[0].item.Id || craftingRecipeNew.craftingRecipesNew[0].itemObject[1].Id == craftingTable.Container.Slots[0].item.Id || craftingRecipeNew.craftingRecipesNew[0].itemObject[2].Id == craftingTable.Container.Slots[0].item.Id) 
        && (craftingRecipeNew.craftingRecipesNew[0].itemObject[0].Id == craftingTable.Container.Slots[1].item.Id || craftingRecipeNew.craftingRecipesNew[0].itemObject[1].Id == craftingTable.Container.Slots[1].item.Id || craftingRecipeNew.craftingRecipesNew[0].itemObject[2].Id == craftingTable.Container.Slots[1].item.Id) 
        && (craftingRecipeNew.craftingRecipesNew[0].itemObject[0].Id == craftingTable.Container.Slots[2].item.Id || craftingRecipeNew.craftingRecipesNew[0].itemObject[1].Id == craftingTable.Container.Slots[2].item.Id || craftingRecipeNew.craftingRecipesNew[0].itemObject[2].Id == craftingTable.Container.Slots[2].item.Id))
        {
            Item _item = new Item(craftingRecipeNew.craftingRecipesNew[0].result);
            craftButton.SetActive(true);
            if(craftingOutput1 == true)
            {
                if(inventory.AddItems(_item, 1))
                {
                    Debug.Log("Result: " + craftingRecipeNew.craftingRecipesNew[0].result.data.Name);
                    for (int i = 0; i < craftingTable.Container.Slots.Length; i++)
                    {
                        craftingTable.Container.Slots[i].RemoveItem();
                        craftingOutput1 = false;
                        craftButton.SetActive(false);
                    }
                }
            }
        }
    }

    public void CraftRecipe1Output()
    {
        craftingOutput1 = true;
    }

    public void CraftRecipe2()
    {
        if((craftingRecipeNew.craftingRecipesNew[1].itemObject[0].Id == craftingTable.Container.Slots[0].item.Id || craftingRecipeNew.craftingRecipesNew[1].itemObject[1].Id == craftingTable.Container.Slots[0].item.Id || craftingRecipeNew.craftingRecipesNew[1].itemObject[2].Id == craftingTable.Container.Slots[0].item.Id) 
        && (craftingRecipeNew.craftingRecipesNew[1].itemObject[0].Id == craftingTable.Container.Slots[1].item.Id || craftingRecipeNew.craftingRecipesNew[1].itemObject[1].Id == craftingTable.Container.Slots[1].item.Id || craftingRecipeNew.craftingRecipesNew[1].itemObject[2].Id == craftingTable.Container.Slots[1].item.Id) 
        && (craftingRecipeNew.craftingRecipesNew[1].itemObject[0].Id == craftingTable.Container.Slots[2].item.Id || craftingRecipeNew.craftingRecipesNew[1].itemObject[1].Id == craftingTable.Container.Slots[2].item.Id || craftingRecipeNew.craftingRecipesNew[1].itemObject[2].Id == craftingTable.Container.Slots[2].item.Id))
        {
            Item _item = new Item(craftingRecipeNew.craftingRecipesNew[1].result);
            craftButton2.SetActive(true);
            if(craftingOutput2 == true)
            {
                if(inventory.AddItems(_item, 1))
                {
                    Debug.Log("Result: " + craftingRecipeNew.craftingRecipesNew[1].result.data.Name);
                    for (int i = 0; i < craftingTable.Container.Slots.Length; i++)
                    {
                        craftingTable.Container.Slots[i].RemoveItem();
                        craftingOutput2 = false;
                        craftButton2.SetActive(false);
                    }
                }
            }
        }
    }

    public void CraftRecipe2Output()
    {
        craftingOutput2 = true;
    }
}