using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGoldManager : MonoBehaviour
{
    public Text playerGoldText;
    public int playerGold;

    // Start is called before the first frame update
    void Start()
    {
        playerGold = 0;    
    }

    // Update is called once per frame
    void Update()
    {
        playerGoldText.text = playerGold.ToString();
    }
}
