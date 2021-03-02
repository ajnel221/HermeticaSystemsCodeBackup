using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryManager : MonoBehaviour
{
    public InventoryObject inventory;
    public InventoryObject equipment;
    public InventoryObject craftingTable;
    public InventoryObject chest;
    public InventoryObject blacksmithing;
    public InventoryObject herbalisim;
    public InventoryObject quest;
    public GameObject pressEToOpen;
    public Text strengthText;
    public Text armorText;
    public Text magickaText;
    public Text agilityText;

   // public bool inventoryIsOpen = false;
   // public GameObject inventoryHolder;

    public Attribute[] attributes;

    private void Start()
    {
        for (int i = 0; i < attributes.Length; i++)
        {
            attributes[i].SetParent(this);
        }

        for (int i = 0; i < equipment.GetSlots.Length; i++)
        {
            equipment.GetSlots[i].OnBeforeUpdate += OnBeforeSlotUpdate;
            equipment.GetSlots[i].OnAfterUpdate += OnAfterSlotUpdate;
        }

        pressEToOpen.SetActive(false);
    }

    public void OnBeforeSlotUpdate(InventorySlot _slot)
    {
        if(_slot.ItemObject == null)
        {
            return;
        }

        switch (_slot.parent.inventory.type)
        {
            case InterfaceType.Inventory:
                break;
            case InterfaceType.Equipment:

                for (int i = 0; i < _slot.item.buffs.Length; i++)
                {
                    for (int j = 0; j < attributes.Length; j++)
                    {
                        if(attributes[j].type == _slot.item.buffs[i].attributes)
                        {
                            attributes[j].value.RemoveModfier(_slot.item.buffs[i]);
                        }
                    }
                }

                break;
            case InterfaceType.CraftingTable:
                break;
            case InterfaceType.Chest:
                break;
            case InterfaceType.Blacksmithing:
                break;
            case InterfaceType.Herbalism:
                break;
            case InterfaceType.Quest:
                break;
            default:
                break;
        }
    }

    public void OnAfterSlotUpdate(InventorySlot _slot)
    {
        if(_slot.ItemObject == null)
        {
            return;
        }

        switch (_slot.parent.inventory.type)
        {
            case InterfaceType.Inventory:
                break;
            case InterfaceType.Equipment:

                for (int i = 0; i < _slot.item.buffs.Length; i++)
                {
                    for (int j = 0; j < attributes.Length; j++)
                    {
                        if(attributes[j].type == _slot.item.buffs[i].attributes)
                        {
                            attributes[j].value.AddModfier(_slot.item.buffs[i]);
                        }
                    }
                }
                break;
            case InterfaceType.CraftingTable:
                break;
            case InterfaceType.Chest:
                break;
            case InterfaceType.Blacksmithing:
                break;
            case InterfaceType.Herbalism:
                break;
            case InterfaceType.Quest:
                break;
            default:
                break;
        } 
    }
    
    public void OnTriggerStay(Collider other) 
    {
        pressEToOpen.SetActive(true);
        var item = other.GetComponent<GroundItem>();
        if(item && Input.GetKey(KeyCode.E))
        {
            Item _item = new Item(item.item);

            if(inventory.AddItems(_item, 1))
            {
                pressEToOpen.SetActive(false);
                Destroy(other.gameObject);
            }
        }    
    }

    void OnTriggerExit(Collider other)
    {
        pressEToOpen.SetActive(false);
    }

    private void Update() 
    {
        /* if(Input.GetKeyDown(KeyCode.I))
        {
            inventory.Save();
            equipment.Save();
            craftingTable.Save();
            //inventoryIsOpen = false;
            //inventoryHolder.SetActive(false);
        }

        else if(Input.GetKeyDown(KeyCode.R))
        {
            inventory.Load();
            equipment.Load();
            craftingTable.Load();
            // inventoryIsOpen = true;
            //inventoryHolder.SetActive(true);
        }

        /*if(Input.GetKeyDown(KeyCode.I) && inventoryIsOpen == false)
        {
            inventory.Load();
            inventoryIsOpen = true;
            inventoryHolder.SetActive(true);
        }*/
    }

    public void AttributeModified(Attribute attribute)
    {
        //Debug.Log(string.Concat(attribute.type," was updated! Value is now ", attribute.value.ModifiedValue));
        strengthText.text = attributes[0].value.ModifiedValue.ToString();
        armorText.text = attributes[1].value.ModifiedValue.ToString();
        magickaText.text = attributes[2].value.ModifiedValue.ToString();
        agilityText.text = attributes[3].value.ModifiedValue.ToString();
    }

    private void OnApplicationQuit() 
    {
        inventory.Clear();
        equipment.Clear();
        craftingTable.Clear();
        chest.Clear();
        blacksmithing.Clear();
        herbalisim.Clear();
        quest.Clear();
    }
}

[System.Serializable]
public class Attribute
{
    [System.NonSerialized]
    public PlayerInventoryManager parent;
    public Attributes type;
    public ModifiableInt value;

    public void SetParent(PlayerInventoryManager _parent)
    {
        parent = _parent;
        value = new ModifiableInt(AttributeModified);
    }

    public void AttributeModified()
    {
        parent.AttributeModified(this);
    }
}