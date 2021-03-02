using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class SavingLoading : MonoBehaviour
{
    public static SavingLoading instance;
    public InventoryObject inventory;
    public InventoryObject equipment;
    public GameObject player;
    public PlayerPosClass posClass;
    public PlayerQuestClass quests;
    public MainQuestGiver currentMainQuest;
    public PlayerHealthbar playerHealthbar;

    public void Start()
    {
        if(MainMenuLoading.instance.loadSaveData == true)
        {
            LoadGame();
        }

        else
        {
            MainMenuLoading.instance.loadSaveData = false;
        }
    }

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

    public bool IsSaveFile()
    {
        return Directory.Exists(Application.persistentDataPath + "/Game_Save");
    }

    public void SaveGame()
    {
        posClass.posX = player.transform.position.x;
        posClass.posY = player.transform.position.y;
        posClass.posZ = player.transform.position.z;
        posClass.rotX = player.transform.rotation.x;
        posClass.rotY = player.transform.rotation.y;
        posClass.rotZ = player.transform.rotation.z;

        quests.questNumber = currentMainQuest.currentQuestInt;

        if(!IsSaveFile())
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Game_Save");
        }

        if(!Directory.Exists(Application.persistentDataPath + "/Game_Save/Character_Data"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Game_Save/Character_Data");
        }

        BinaryFormatter bf = new BinaryFormatter();

        FileStream inventoryFile = File.Create(Application.persistentDataPath + "/Game_Save/Character_Data/InventoryData.txt");
        FileStream equipmentFile = File.Create(Application.persistentDataPath + "/Game_Save/Character_Data/EquipmentData.txt");
        FileStream playerPositionFile = File.Create(Application.persistentDataPath + "/Game_Save/Character_Data/PlayerPositionData.txt");
        FileStream playerMainQuestFile = File.Create(Application.persistentDataPath + "/Game_Save/Character_Data/PlayerMainQuestData.txt");

        var json = JsonUtility.ToJson(inventory);
        var json1 = JsonUtility.ToJson(equipment);
        var json2 = JsonUtility.ToJson(posClass);
        var json3 = JsonUtility.ToJson(quests);
        
        bf.Serialize(inventoryFile, json);
        bf.Serialize(equipmentFile, json1);
        bf.Serialize(playerPositionFile, json2);
        bf.Serialize(playerMainQuestFile, json3);
        
        inventoryFile.Close();
        equipmentFile.Close();
        playerPositionFile.Close();
        playerMainQuestFile.Close();
    }

    public void LoadGame()
    {
        Time.timeScale = 1f;
        playerHealthbar.healthLength = 424.58f;
        playerHealthbar.deathMenu.SetActive(false);
        playerHealthbar.bloodSide.active = false;
        playerHealthbar.playerAnim.Play("Idle_Basic");

        if(!Directory.Exists(Application.persistentDataPath + "/Game_Save/Character_Data"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Game_Save/Character_Data");
        }

        BinaryFormatter bf = new BinaryFormatter();

        if(File.Exists(Application.persistentDataPath + "/Game_Save/Character_Data/InventoryData.txt"))
        {
            FileStream inventoryFile = File.Open(Application.persistentDataPath + "/Game_Save/Character_Data/InventoryData.txt", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(inventoryFile), inventory);

            for (int i = 0; i < inventory.GetSlots.Length; i++)
            {
                inventory.Container.Slots[i].UpdateSlot(inventory.Container.Slots[i].item, inventory.Container.Slots[i].amount);
            }

            inventoryFile.Close();
        }

        if(File.Exists(Application.persistentDataPath + "/Game_Save/Character_Data/EquipmentData.txt"))
        {
            FileStream equipmentFile = File.Open(Application.persistentDataPath + "/Game_Save/Character_Data/EquipmentData.txt", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(equipmentFile), equipment);

            for (int i = 0; i < equipment.GetSlots.Length; i++)
            {
                equipment.Container.Slots[i].UpdateSlot(equipment.Container.Slots[i].item, equipment.Container.Slots[i].amount);
            }

            equipmentFile.Close();
        }

        if(File.Exists(Application.persistentDataPath + "/Game_Save/Character_Data/PlayerPositionData.txt"))
        {
            FileStream playerPositionFile = File.Open(Application.persistentDataPath + "/Game_Save/Character_Data/PlayerPositionData.txt", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(playerPositionFile), posClass);
            player.transform.position = new Vector3(posClass.posX, posClass.posY, posClass.posZ);
            player.transform.rotation = new Quaternion(posClass.rotX, posClass.rotY, posClass.rotZ, 0);
            playerPositionFile.Close();
        }

        if(File.Exists(Application.persistentDataPath + "/Game_Save/Character_Data/PlayerMainQuestData.txt"))
        {
            FileStream playerMainQuestFile = File.Open(Application.persistentDataPath + "/Game_Save/Character_Data/PlayerMainQuestData.txt", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(playerMainQuestFile), quests);
            currentMainQuest.currentQuestInt = quests.questNumber;
            playerMainQuestFile.Close();
        }
    }
}
