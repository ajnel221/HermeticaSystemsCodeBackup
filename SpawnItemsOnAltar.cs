using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItemsOnAltar : MonoBehaviour
{
    private GameObject spawningItem1;
    private GameObject spawningItem2;
    private GameObject spawningItem3;
    private GameObject spawningItem4;
    public Transform item1Holder;
    public Transform item2Holder;
    public Transform item3Holder;
    public Transform item4Holder;
    public Vector3 item1Vector3Position;
    public Vector3 item1RotationVector;
    public Vector3 item2Vector3Position;
    public Vector3 item2RotationVector;
    public Vector3 item3Vector3Position;
    public Vector3 item3RotationVector;
    public Vector3 item4Vector3Position;
    public Vector3 item4RotationVector;
    public ItemDatabaseObject databaseObject;
    public InventoryObject items;
    public bool isInstantiated1 = false;
    public bool dontInstantiate1 = false;
    public bool isInstantiated2 = false;
    public bool dontInstantiate2 = false;
    public bool isInstantiated3 = false;
    public bool dontInstantiate3 = false;
    public bool isInstantiated4 = false;
    public bool dontInstantiate4 = false;
    public bool isItem1 = false;
    public bool isItem2 = false;
    public bool isItem3 = false;
    public bool isItem4 = false;


    void Update()
    {
        SpawnItem1();   
        SpawnItem2(); 
        SpawnItem3(); 
        DeleteItem1();   
        DeleteItem2(); 
        DeleteItem3(); 
    }

    public void SpawnItem1()
    {
        for (int i = 0; i < databaseObject.ItemObject.Length; i++)
        {
            if(items.Container.Slots[1].item.Id == databaseObject.ItemObject[i].data.Id)
            {
                isItem1 = true;
                spawningItem1 = databaseObject.ItemObject[i].gameItem;
                IsItem1();
            }

            else if(items.Container.Slots[1].item.Id != databaseObject.ItemObject[i].data.Id)
            {
                isItem1 = false;
                IsItem1();
            }
        }   
    }

    public void SpawnItem2()
    {
        for (int k = 0; k < databaseObject.ItemObject.Length; k++)
        {
            if(items.Container.Slots[2].item.Id == databaseObject.ItemObject[k].data.Id)
            {
                isItem2 = true;
                spawningItem2 = databaseObject.ItemObject[k].gameItem;
                IsItem2();
            }

            else if(items.Container.Slots[2].item.Id != databaseObject.ItemObject[k].data.Id)
            {
                isItem2 = false;
                IsItem2();
            }
        }  
    }

    public void SpawnItem3()
    {
        for (int r = 0; r < databaseObject.ItemObject.Length; r++)
        {
            if(items.Container.Slots[0].item.Id == databaseObject.ItemObject[r].data.Id)
            {
                isItem3 = true;
                spawningItem3 = databaseObject.ItemObject[r].gameItem;
                IsItem3();
            }

            else if(items.Container.Slots[0].item.Id != databaseObject.ItemObject[r].data.Id)
            {
                isItem3 = false;
                IsItem3();
            }
        }
    }

    public void SpawnItem4()
    {

    }

    public void IsItem1()
    {
        if(isItem1 == true && isInstantiated1 == false && dontInstantiate1 == false)
        {
            GameObject itemInstance;
            itemInstance = Instantiate(spawningItem1, item1Vector3Position, Quaternion.Euler(item1RotationVector)) as GameObject;

            itemInstance.transform.SetParent(item1Holder, false);
            if(items.Container.Slots[1].item.Id == 0)
            {
                itemInstance.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
                itemInstance.layer = 16;
            }

            else if(items.Container.Slots[1].item.Id == 9)
            {
                itemInstance.transform.localScale = new Vector3(1f, 1f, 1f);
                itemInstance.layer = 16;
            }

            else if(items.Container.Slots[1].item.Id == 10)
            {
                itemInstance.transform.localScale = new Vector3(1f, 1f, 1f);
                itemInstance.layer = 16;
            }

            else if(items.Container.Slots[1].item.Id == 11)
            {
                itemInstance.transform.localScale = new Vector3(1f, 1f, 1f);
                itemInstance.layer = 16;
            }

            else if(items.Container.Slots[1].item.Id == 27)
            {
                itemInstance.transform.localScale = new Vector3(1f, 1f, 1f);
                itemInstance.transform.rotation = new Quaternion(-90, 0, 0, 0);
                itemInstance.layer = 16;
            }

            isInstantiated1 = true;
            dontInstantiate1 = true;
        }
    }

    public void IsItem2()
    {
        if(isItem2 == true && isInstantiated2 == false && dontInstantiate2 == false)
        {
            GameObject itemInstance2;
            itemInstance2 = Instantiate(spawningItem2, item2Vector3Position, Quaternion.Euler(item2RotationVector)) as GameObject;

            itemInstance2.transform.SetParent(item2Holder, false);
            if(items.Container.Slots[2].item.Id == 0)
            {
                itemInstance2.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
                itemInstance2.layer = 16;
            }

            else if(items.Container.Slots[2].item.Id == 9)
            {
                itemInstance2.transform.localScale = new Vector3(1f, 1f, 1f);
                itemInstance2.layer = 16;
            }

            else if(items.Container.Slots[2].item.Id == 10)
            {
                itemInstance2.transform.localScale = new Vector3(1f, 1f, 1f);
                itemInstance2.layer = 16;
            }

            else if(items.Container.Slots[2].item.Id == 11)
            {
                itemInstance2.transform.localScale = new Vector3(1f, 1f, 1f);
                itemInstance2.layer = 16;
            }

            else if(items.Container.Slots[2].item.Id == 27)
            {
                itemInstance2.transform.localScale = new Vector3(1f, 1f, 1f);
                itemInstance2.transform.rotation = new Quaternion(-90, 0, 0, 0);
                itemInstance2.layer = 16;
            }

            isInstantiated2 = true;
            dontInstantiate2 = true;
        }
    }

    public void IsItem3()
    {
        if(isItem3 == true && isInstantiated3 == false && dontInstantiate3 == false)
        {
            GameObject itemInstance3;
            itemInstance3 = Instantiate(spawningItem3, item3Vector3Position, Quaternion.Euler(item3RotationVector)) as GameObject;

            itemInstance3.transform.SetParent(item3Holder, false);
            if(items.Container.Slots[0].item.Id == 0)
            {
                itemInstance3.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
                itemInstance3.layer = 16;
            }

            else if(items.Container.Slots[0].item.Id == 9)
            {
                itemInstance3.transform.localScale = new Vector3(1f, 1f, 1f);
                itemInstance3.layer = 16;
            }

            else if(items.Container.Slots[0].item.Id == 10)
            {
                itemInstance3.transform.localScale = new Vector3(1f, 1f, 1f);
                itemInstance3.layer = 16;
            }

            else if(items.Container.Slots[0].item.Id == 11)
            {
                itemInstance3.transform.localScale = new Vector3(1f, 1f, 1f);
                itemInstance3.layer = 16;
            }

            else if(items.Container.Slots[0].item.Id == 27)
            {
                itemInstance3.transform.localScale = new Vector3(1f, 1f, 1f);
                itemInstance3.transform.rotation = new Quaternion(-90, 0, 0, 0);
                itemInstance3.layer = 16;
            }

            isInstantiated3 = true;
            dontInstantiate3 = true;
        }
    }

    public void IsItem4()
    {

    }

    public void DeleteItem1()
    {
        if(items.Container.Slots[1].item.Id == -1 && isInstantiated1 == true)
        {
            dontInstantiate1 = false;
            isInstantiated1 = false;
            GameObject.Destroy(item1Holder.transform.GetChild(0).gameObject);
            items.Container.Slots[1].item.Id = -1;
        }
    }

    public void DeleteItem2()
    {
        if(items.Container.Slots[2].item.Id == -1 && isInstantiated2 == true)
        {
            dontInstantiate2 = false;
            isInstantiated2 = false;
            GameObject.Destroy(item2Holder.transform.GetChild(0).gameObject);
            items.Container.Slots[2].item.Id = -1;
        }
    }

    public void DeleteItem3()
    {
        if(items.Container.Slots[0].item.Id == -1 && isInstantiated3 == true)
        {
            dontInstantiate3 = false;
            isInstantiated3 = false;
            GameObject.Destroy(item3Holder.transform.GetChild(0).gameObject);
            items.Container.Slots[0].item.Id = -1;
        }
    }

    public void DeleteItem4()
    {
    
    }
}