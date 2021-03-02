using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    public GameObject inventoryAnvilRenderer;
    public RectTransform craftingHolder;
    public RectTransform inventory;
    public RectTransform equipment;
    public Min minimize;
    public RectTransform chestScreen;
    public GameObject openMessage;
    public Transform equipmentMenu;
    //public bool isOpen;
    public bool canOpen = true;

    // Start is called before the first frame update
    void Start()
    {
        inventoryAnvilRenderer.SetActive(false);
        //isOpen = false;
        chestScreen.localScale = new Vector3 (0,0,0);
        openMessage.SetActive(false);
        craftingHolder.localScale = new Vector3 (0,0,0);
        inventory.localScale = new Vector3 (0,0,0);
        craftingHolder.localScale = new Vector3 (0,0,0);
        chestScreen.localScale = new Vector3 (0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.E) && isOpen == true)
        {
            equipmentMenu.localScale = new Vector3 (0,0,0);
            chestScreen.SetActive(true);
            openMessage.SetActive(false);
        }*/

        //OpenItems();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && canOpen == true)
        {
            //canOpen = true;
            openMessage.SetActive(true);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && Input.GetKey(KeyCode.E) && canOpen == true && minimize.isOpen == false)
        {
            minimize.isOpen = true;
            canOpen = false;
            chestScreen.localScale = new Vector3 (1,1,1);
            openMessage.SetActive(false);
            OpenItems();
        }
    }

    void OnTriggerExit(Collider other)
    {
        minimize.isOpen = false;
        chestScreen.localScale = new Vector3 (0,0,0);
        openMessage.SetActive(false);
        canOpen = true;
        CloseItems();
    }

    public void OpenItems()
    {
        chestScreen.localScale = new Vector3 (1,1,1);
        craftingHolder.localScale = new Vector3 (1,1,1);
        inventory.localScale = new Vector3 (1,1,1);
        equipment.localScale = new Vector3 (1,1,1);
        inventoryAnvilRenderer.SetActive(true);
    }

    public void CloseItems()
    {
        chestScreen.localScale = new Vector3 (0,0,0);
        craftingHolder.localScale = new Vector3 (0,0,0);
        inventory.localScale = new Vector3 (0,0,0);
        equipment.localScale = new Vector3 (0,0,0);
        inventoryAnvilRenderer.SetActive(false);
    }
}