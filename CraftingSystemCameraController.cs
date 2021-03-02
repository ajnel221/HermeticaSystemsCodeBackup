using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSystemCameraController : MonoBehaviour
{
    public TestCrafting testCrafting;
    public GameObject playerMainCamera;
    public GameObject playerContoller;
    public GameObject inventoryAnvilRenderer;
    public RectTransform craftingHolder;
    private PlayerMovementScript playerMovementScript;
    private MouseLook mouseLook;
    public GameObject blacksmithing;
    public OpenChest foundAnvil;

    // Start is called before the first frame update
    void Start()
    {
        inventoryAnvilRenderer.SetActive(false);
        mouseLook = playerMainCamera.GetComponent<MouseLook>();
        foundAnvil = blacksmithing.GetComponent<OpenChest>();
        testCrafting.inventoryMenu.localScale = new Vector3 (0,0,0);
        craftingHolder.localScale = new Vector3 (0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if(foundAnvil.canOpen == false)
        {
            inventoryAnvilRenderer.SetActive(true);
            //playerMainCamera.SetActive(false);
            mouseLook.enabled = false;
        }

        else if(foundAnvil.canOpen == true)
        {
            inventoryAnvilRenderer.SetActive(false);
            //playerMainCamera.SetActive(true);
            mouseLook.enabled = true;
        }
    }
}
