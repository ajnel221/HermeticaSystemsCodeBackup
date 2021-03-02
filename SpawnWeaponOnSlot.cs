using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;
using System.Runtime.Serialization;

public class SpawnWeaponOnSlot : MonoBehaviour
{   
    [Header ("Player Animator")]
    //public Animator playerAnim;
    
    [Header ("Weapon Holder")]
    public Transform weaponHolder;

    [Header ("Shield Holder")]
    public Transform shieldHolder;

    [Header ("Helmet Holder")]
    public Transform helmetHolder;

    [Header ("Shoulder Holders")]
    public Transform shoulderHolderLeft;
    public Transform shoulderHolderRight;
    public GameObject shoulderLeft;
    public GameObject shoulderRight;

    [Header ("Bracer Holders")]
    public Transform bracerHolderLeft;
    public Transform bracerHolderRight;
    public GameObject bracerLeft;
    public GameObject bracerRight;

    [Header ("Armor Holders")]
    public Transform armorHolder;

    [Header ("Databases")]
    public ItemDatabaseObject databaseObject;
    public InventoryObject equipment;
    

    [Header ("Templar Sword")]
    public Vector3 newVector3Position;
    public Vector3 rotationVector;
    private GameObject spawningItem;
    public bool isSword = false;
    public bool isInstantiated = false;
    public bool dontInstantiate = false;
    public bool isMainHandSpawn = false;
    

    [Header ("Templar Helmet")]
    public Vector3 helmetVector3Position;
    public Vector3 helmetRotationVector;
    private GameObject helmetSpawningHelmet;
    public bool helmetIsInstantiated = false;
    public bool helmetDontInstantiate = false;
    public bool isHelmetSpawn = false;
    public bool isHelmet = false;


    [Header ("Leather Helmet")]
    public Vector3 leatherHelmetVector3Position;
    public Vector3 leatherHelmetRotationVector;
    private GameObject leatherHelmetSpawning;
    public bool leatherHelmetIsInstantiated = false;
    public bool leatherHelmetDontInstantiate = false;
    public bool isLeatherHelmetSpawn = false;
    public bool isLeatherHelmet = false;


    [Header ("Leather Armor")]
    public Vector3 leatherArmorVector3Position;
    public Vector3 leatherArmorRotationVector;
    private GameObject leatherArmorSpawning;
    public bool leatherArmorIsInstantiated = false;
    public bool leatherArmorDontInstantiate = false;
    public bool isLeatherArmorSpawn = false;
    public bool isLeatherArmor = false;


    [Header ("Leather Shoulders")]
    public Vector3 leatherShouldersLeftVector3Position;
    public Vector3 leatherShouldersRightVector3Position;
    public Vector3 leatherShouldersLeftRotationVector;
    public Vector3 leatherShouldersRightRotationVector;
    private GameObject leatherShoulderLeftSpawning;
    private GameObject leatherShoulderRightSpawning;
    public bool leatherShouldersIsInstantiated = false;
    public bool leatherShouldersDontInstantiate = false;
    public bool isLeatherShouldersSpawn = false;
    public bool isLeatherShoulders = false;

    [Header ("Leather Bracers")]
    public Vector3 leatherBracersLeftVector3Position;
    public Vector3 leatherBracersRightVector3Position;
    public Vector3 leatherBracersLeftRotationVector;
    public Vector3 leatherBracersRightRotationVector;
    private GameObject leatherBracersLeftSpawning;
    private GameObject leatherBracersRightSpawning;
    public bool leatherBracersIsInstantiated = false;
    public bool leatherBracersDontInstantiate = false;
    public bool isLeatherBracersSpawn = false;
    public bool isLeatherBracers = false;


    [Header ("Kite Shield")]
    public Vector3 shieldVector3Position;
    public Vector3 shieldRotationVector;
    private GameObject shieldSpawningItem;
    public bool shieldIsInstantiated = false;
    public bool shieldDontInstantiate = false;
    public bool isShield = false;
    public bool isOffHandSpawned = false;
    

    [Header ("GreatSword")]
    public Vector3 sword2Vector3Position;
    public Vector3 sword2RotationVector;
    private GameObject sword2SpawningItem;
    public bool sword2IsInstantiated = false;
    public bool sword2DontInstantiate = false;
    public bool isSword2Spawn = false;
    public bool isSword2 = false;


    [Header ("Fire GreatSword")]
    public Vector3 fireSwordVector3Position;
    public Vector3 fireSwordRotationVector;
    private GameObject fireSwordSpawningItem;
    public bool fireSwordIsInstantiated = false;
    public bool fireSwordDontInstantiate = false;
    public bool isFireSwordSpawn = false;
    public bool isFireSword = false;


    [Header ("Electric GreatSword")]
    public Vector3 electricSwordVector3Position;
    public Vector3 electricSwordRotationVector;
    private GameObject electricSwordSpawningItem;
    public bool electricSwordIsInstantiated = false;
    public bool electricSwordDontInstantiate = false;
    public bool iselectricSwordSpawn = false;
    public bool iselectricSword = false;

    //private GameObject sword;
    //private GameObject crossbow;

    public void Start()
    {
        //weaponHolder.GetComponent<Transform>();
    }

    public void Update()
    {
        SpawnItem();
        DeleteOffHand();
        DeleteMainHand();
        DeleteHelmet();
        DeleteLeatherHelmet();
        DeleteLeatherArmor();
        DeleteLeatherShoulders();
        DeleteLeatherBracers();
    }

    public void SpawnItem()
    {
        if(equipment.Container.Slots[4].item.Id == databaseObject.ItemObject[6].data.Id)
        {
            isSword = true;
            spawningItem = databaseObject.ItemObject[6].gameItem;
            IsSword();
        }

        else if(equipment.Container.Slots[4].item.Id != databaseObject.ItemObject[6].data.Id)
        {
            isSword = false;
            IsSword();
        }

        if(equipment.Container.Slots[4].item.Id == databaseObject.ItemObject[7].data.Id)
        {
            isSword2 = true;
            sword2SpawningItem = databaseObject.ItemObject[7].gameItem;
            IsSword2();
        }

        else if(equipment.Container.Slots[4].item.Id != databaseObject.ItemObject[7].data.Id)
        {
            isSword2 = false;
            IsSword2();
        }

        if(equipment.Container.Slots[5].item.Id == databaseObject.ItemObject[16].data.Id)
        {
            isShield = true;
            spawningItem = databaseObject.ItemObject[16].gameItem;
            IsShield();
        }

        else if(equipment.Container.Slots[5].item.Id != databaseObject.ItemObject[16].data.Id)
        {
            isShield = false;
            IsShield();
        }

        if(equipment.Container.Slots[0].item.Id == databaseObject.ItemObject[0].data.Id)
        {
            isHelmet = true;
            helmetSpawningHelmet = databaseObject.ItemObject[0].gameItem;
            Helmet();
        }

        else if(equipment.Container.Slots[0].item.Id != databaseObject.ItemObject[0].data.Id)
        {
            isHelmet = false;
            Helmet();
        }

        if(equipment.Container.Slots[0].item.Id == databaseObject.ItemObject[20].data.Id)
        {
            isLeatherHelmet = true;
            leatherHelmetSpawning = databaseObject.ItemObject[20].gameItem;
            LeatherHelmet();
        }

        else if(equipment.Container.Slots[0].item.Id != databaseObject.ItemObject[20].data.Id)
        {
            isLeatherHelmet = false;
            LeatherHelmet();
        }

        if(equipment.Container.Slots[1].item.Id == databaseObject.ItemObject[21].data.Id)
        {
            isLeatherArmor = true;
            leatherArmorSpawning = databaseObject.ItemObject[21].gameItem;
            LeatherArmor();
        }

        else if(equipment.Container.Slots[1].item.Id != databaseObject.ItemObject[21].data.Id)
        {
            isLeatherArmor = false;
            LeatherArmor();
        }

        if(equipment.Container.Slots[4].item.Id == databaseObject.ItemObject[14].data.Id)
        {
            isFireSword = true;
            fireSwordSpawningItem = databaseObject.ItemObject[14].gameItem;
            IsFireSword();
        }

        else if(equipment.Container.Slots[4].item.Id != databaseObject.ItemObject[14].data.Id)
        {
            isFireSword = false;
            IsFireSword();
        }

        if(equipment.Container.Slots[4].item.Id == databaseObject.ItemObject[19].data.Id)
        {
            iselectricSword = true;
            electricSwordSpawningItem = databaseObject.ItemObject[19].gameItem;
            IsElectricSword();
        }

        else if(equipment.Container.Slots[4].item.Id != databaseObject.ItemObject[19].data.Id)
        {
            iselectricSword = false;
            IsElectricSword();
        }

        if(equipment.Container.Slots[6].item.Id == databaseObject.ItemObject[22].data.Id)
        {
            isLeatherShoulders = true;
            leatherShoulderLeftSpawning = shoulderLeft;
            leatherShoulderRightSpawning = shoulderRight;
            IsLeatherShoulder();
        }

        else if(equipment.Container.Slots[6].item.Id != databaseObject.ItemObject[22].data.Id)
        {
            isLeatherShoulders = false;
            IsLeatherShoulder();
        }

        if(equipment.Container.Slots[7].item.Id == databaseObject.ItemObject[26].data.Id)
        {
            isLeatherBracers = true;
            leatherBracersLeftSpawning = bracerLeft;
            leatherBracersRightSpawning = bracerRight;
            IsLeatherBracers();
        }

        else if(equipment.Container.Slots[7].item.Id != databaseObject.ItemObject[26].data.Id)
        {
            isLeatherBracers = false;
            IsLeatherBracers();
        }
    }

    public void IsSword()
    {
        if(isSword == true && isInstantiated == false && dontInstantiate == false)
        {
            isMainHandSpawn = true;
            isShield = false;
            GameObject itemInstance;
            itemInstance = Instantiate(spawningItem, newVector3Position, Quaternion.Euler(rotationVector)) as GameObject;
            itemInstance.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            itemInstance.layer = 17;
            itemInstance.tag = "Sword";
            itemInstance.transform.SetParent(weaponHolder, false);
            isInstantiated = true;
            dontInstantiate = true;
        }
    }

    public void IsSword2()
    {
        if(isSword2 == true && sword2IsInstantiated == false && sword2DontInstantiate == false)
        {
            isSword2Spawn = true;
            isShield = false;
            GameObject itemInstance3;
            itemInstance3 = Instantiate(sword2SpawningItem, sword2Vector3Position, Quaternion.Euler(sword2RotationVector)) as GameObject;
            itemInstance3.transform.SetParent(weaponHolder, false);
            itemInstance3.transform.localScale = new Vector3(300f, 300f, 300f);
            itemInstance3.layer = 17;
            itemInstance3.tag = "Sword";
            sword2IsInstantiated = true;
            sword2DontInstantiate = true;
        }
    }

    public void IsShield()
    {
        if(isShield == true && shieldIsInstantiated == false && shieldDontInstantiate == false)
        {
            isOffHandSpawned = true;
            GameObject itemInstance1;
            itemInstance1 = Instantiate(spawningItem, shieldVector3Position, Quaternion.Euler(shieldRotationVector)) as GameObject;
            itemInstance1.transform.localScale = new Vector3(6f, 6f, 6f);
            itemInstance1.layer = 17;
            itemInstance1.transform.SetParent(shieldHolder, false);
            shieldIsInstantiated = true;
            shieldDontInstantiate = true;
        }
    }

    public void Helmet()
    {
        if(isHelmet == true && helmetIsInstantiated == false && helmetDontInstantiate == false)
        {
            isHelmetSpawn = true;
            GameObject itemInstance2;
            itemInstance2 = Instantiate(helmetSpawningHelmet, helmetVector3Position, Quaternion.Euler(helmetRotationVector)) as GameObject;
            itemInstance2.transform.localScale = new Vector3(7f, 7f, 7f);
            itemInstance2.layer = 17;
            itemInstance2.transform.SetParent(helmetHolder, false);
            helmetIsInstantiated = true;
            helmetDontInstantiate = true;
        }
    }

    public void LeatherHelmet()
    {
        if(isLeatherHelmet == true && leatherHelmetIsInstantiated == false && leatherHelmetDontInstantiate == false)
        {
            isLeatherHelmetSpawn = true;
            GameObject itemInstance6;
            itemInstance6 = Instantiate(leatherHelmetSpawning, leatherHelmetVector3Position, Quaternion.Euler(leatherHelmetRotationVector)) as GameObject;
            itemInstance6.transform.localScale = new Vector3(1f, 1f, 1f);
            itemInstance6.layer = 17;
            itemInstance6.transform.SetParent(helmetHolder, false);
            leatherHelmetIsInstantiated = true;
            leatherHelmetDontInstantiate = true;
        }
    }

    public void LeatherArmor()
    {
        if(isLeatherArmor == true && leatherArmorIsInstantiated == false && leatherArmorDontInstantiate == false)
        {
            isLeatherArmorSpawn = true;
            GameObject itemInstance7;
            itemInstance7 = Instantiate(leatherArmorSpawning, leatherArmorVector3Position, Quaternion.Euler(leatherArmorRotationVector)) as GameObject;
            itemInstance7.transform.localScale = new Vector3(1.1f, 1.2f, 1f);
            itemInstance7.layer = 17;
            itemInstance7.transform.SetParent(armorHolder, false);
            leatherArmorIsInstantiated = true;
            leatherArmorDontInstantiate = true;
        }
    }

    public void IsLeatherShoulder()
    {
        if(isLeatherShoulders == true && leatherShouldersIsInstantiated == false && leatherShouldersDontInstantiate == false)
        {
            isLeatherShouldersSpawn = true;

            GameObject itemInstance8;
            GameObject itemInstance9;

            itemInstance8 = Instantiate(leatherShoulderLeftSpawning, leatherShouldersLeftVector3Position, Quaternion.Euler(leatherShouldersLeftRotationVector)) as GameObject;
            itemInstance9 = Instantiate(leatherShoulderRightSpawning, leatherShouldersRightVector3Position, Quaternion.Euler(leatherShouldersRightRotationVector)) as GameObject;

            itemInstance8.transform.localScale = new Vector3(100f, 100f, 100f);
            itemInstance9.transform.localScale = new Vector3(100f, 100f, 100f);

            itemInstance8.layer = 17;
            itemInstance9.layer = 17;

            itemInstance8.transform.SetParent(shoulderHolderLeft, false);
            itemInstance9.transform.SetParent(shoulderHolderRight, false);

            leatherShouldersIsInstantiated = true;
            leatherShouldersDontInstantiate = true;
        }
    }

    public void IsLeatherBracers()
    {
        if(isLeatherBracers == true && leatherBracersIsInstantiated == false && leatherBracersDontInstantiate == false)
        {
            isLeatherBracersSpawn = true;

            GameObject itemInstance10;
            GameObject itemInstance11;

            itemInstance10 = Instantiate(leatherBracersLeftSpawning, leatherBracersLeftVector3Position, Quaternion.Euler(leatherBracersLeftRotationVector)) as GameObject;
            itemInstance11 = Instantiate(leatherBracersRightSpawning, leatherBracersRightVector3Position, Quaternion.Euler(leatherBracersRightRotationVector)) as GameObject;

            itemInstance10.transform.localScale = new Vector3(103f, 103f, 103f);
            itemInstance11.transform.localScale = new Vector3(103f, 103f, 103f);

            itemInstance10.layer = 17;
            itemInstance11.layer = 17;

            itemInstance10.transform.SetParent(bracerHolderLeft, false);
            itemInstance11.transform.SetParent(bracerHolderRight, false);

            leatherBracersIsInstantiated = true;
            leatherBracersDontInstantiate = true;
        }
    }

    public void IsFireSword()
    {
        if(isFireSword == true && fireSwordIsInstantiated == false && fireSwordDontInstantiate == false)
        {
            isFireSwordSpawn = true;
            isFireSword = false;
            GameObject itemInstance4;
            itemInstance4 = Instantiate(fireSwordSpawningItem, fireSwordVector3Position, Quaternion.Euler(fireSwordRotationVector)) as GameObject;
            itemInstance4.transform.SetParent(weaponHolder, false);
            itemInstance4.transform.localScale = new Vector3(300f, 300f, 300f);
            itemInstance4.layer = 17;
            foreach (Transform item in itemInstance4.transform)
            {
                item.gameObject.layer = 17;
            }
            itemInstance4.tag = "Sword";
            fireSwordIsInstantiated = true;
            fireSwordDontInstantiate = true;
        }
    }

    public void IsElectricSword()
    {
        if(iselectricSword == true && electricSwordIsInstantiated == false && electricSwordDontInstantiate == false)
        {
            iselectricSwordSpawn = true;
            iselectricSword = false;
            GameObject itemInstance5;
            itemInstance5 = Instantiate(electricSwordSpawningItem, electricSwordVector3Position, Quaternion.Euler(electricSwordRotationVector)) as GameObject;
            itemInstance5.transform.SetParent(weaponHolder, false);
            itemInstance5.transform.localScale = new Vector3(300f, 300f, 300f);
            itemInstance5.layer = 17;
            foreach (Transform item in itemInstance5.transform)
            {
                item.gameObject.layer = 17;
            }
            itemInstance5.tag = "Sword";
            electricSwordIsInstantiated = true;
            electricSwordDontInstantiate = true;
        }
    }

    public void DeleteOffHand()
    {
        if(equipment.Container.Slots[5].item.Id == -1 && shieldIsInstantiated == true)
        {
            isOffHandSpawned = false;
            shieldDontInstantiate = false;
            shieldIsInstantiated = false;
            GameObject.Destroy(shieldHolder.transform.GetChild(0).gameObject);
        }
    }

    public void DeleteMainHand()
    {
        if(equipment.Container.Slots[4].item.Id == -1 && (isInstantiated == true || sword2IsInstantiated == true || fireSwordIsInstantiated == true || electricSwordIsInstantiated == true))
        {
            isMainHandSpawn = false;
            dontInstantiate = false;
            isInstantiated = false;
            sword2DontInstantiate = false;
            sword2IsInstantiated = false;
            isSword2Spawn = false;
            fireSwordDontInstantiate = false;
            fireSwordIsInstantiated = false;
            isFireSwordSpawn = false;
            electricSwordDontInstantiate = false;
            electricSwordIsInstantiated = false;
            iselectricSwordSpawn = false;
            GameObject.Destroy(weaponHolder.transform.GetChild(0).gameObject);
        }
    }

    public void DeleteHelmet()
    {
        if(equipment.Container.Slots[0].item.Id == -1 && helmetIsInstantiated == true)
        {
            isHelmetSpawn = false;
            helmetDontInstantiate = false;
            helmetIsInstantiated = false;
            GameObject.Destroy(helmetHolder.transform.GetChild(2).gameObject);
        }
    }

    public void DeleteLeatherHelmet()
    {
        if(equipment.Container.Slots[0].item.Id == -1 && leatherHelmetIsInstantiated == true)
        {
            isLeatherHelmetSpawn = false;
            leatherHelmetDontInstantiate = false;
            leatherHelmetIsInstantiated = false;
            GameObject.Destroy(helmetHolder.transform.GetChild(2).gameObject);
        }
    }

    public void DeleteLeatherArmor()
    {
        if(equipment.Container.Slots[1].item.Id == -1 && leatherArmorIsInstantiated == true)
        {
            isLeatherArmorSpawn = false;
            leatherArmorDontInstantiate = false;
            leatherArmorIsInstantiated = false;
            GameObject.Destroy(armorHolder.transform.GetChild(1).gameObject);
        }
    }

    public void DeleteLeatherShoulders()
    {
        
        if(equipment.Container.Slots[6].item.Id == -1 && leatherShouldersIsInstantiated == true)
        {
            isLeatherShouldersSpawn = false;
            leatherShouldersDontInstantiate = false;
            leatherShouldersIsInstantiated = false;
            GameObject.Destroy(shoulderHolderLeft.transform.GetChild(0).gameObject);
            GameObject.Destroy(shoulderHolderRight.transform.GetChild(0).gameObject);
        }
    }

    public void DeleteLeatherBracers()
    {
        
        if(equipment.Container.Slots[7].item.Id == -1 && leatherBracersIsInstantiated == true)
        {
            isLeatherBracersSpawn = false;
            leatherBracersDontInstantiate = false;
            leatherBracersIsInstantiated = false;
            GameObject.Destroy(bracerHolderLeft.transform.GetChild(1).gameObject);
            GameObject.Destroy(bracerHolderRight.transform.GetChild(1).gameObject);
        }
    }
}