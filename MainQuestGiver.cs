using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainQuestGiver : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    private AudioClip questAudioClip;
    public PlayerGoldManager playerGold;
    public QuestObject[] quest;
    private QuestObject current;
    private GameObject clone;
    public GameObject panel;
    public bool giveQuest = false;
    public bool questIsActive = false;
    public bool removeQuest = false;
    public int range;
    public int currentQuestInt = 0;
    public InventoryObject questInv;

    public void ActivateVairiables()
    {
        if(giveQuest == false && questIsActive == false && removeQuest == false)
        {
            giveQuest = true;
            questIsActive = false;
            removeQuest = false;
        }
        GiveNewQuest();
        QuestCheck();
    }

    public void GiveNewQuest()
    {
        if(giveQuest == true && questIsActive == false && removeQuest == false)
        {
            range = currentQuestInt;
            current = quest[range];
            questAudioClip = quest[range].questSound;
            audioSource.volume = 1f;
            audioSource.PlayOneShot(questAudioClip);
            GameObject newText = Instantiate(current.questText, Vector2.zero, Quaternion.identity);
            newText.transform.SetParent(panel.transform, false);
            clone = GameObject.Find("_UI/Canvas/Panel (1)/Quest(Clone)");
            Text clone1 = clone.GetComponent<Text>();
            clone1.text = current.questDescription;

            giveQuest = false;
            questIsActive = true;
            removeQuest = false;
        }
    }

    public void WantToRemove()
    {
        giveQuest = false;
        questIsActive = true;
        removeQuest = true;
        
        DeleteQuest();
    }

    public void DeleteQuest()
    {
        if(giveQuest == false && questIsActive == true && removeQuest == true)
        {
            currentQuestInt = range;
            Destroy(GameObject.Find("_UI/Canvas/Panel (1)/Quest(Clone)"));
            giveQuest = false;
            questIsActive = false;
            removeQuest = false;
        }
    }

    public void QuestCheck()
    {
        if(questInv.Container.Slots[0].item.Id == current.item.data.Id)
        {
            playerGold.playerGold = playerGold.playerGold + current.goldToGive;
            currentQuestInt = currentQuestInt + 1;
            Destroy(GameObject.Find("_UI/Canvas/Panel (1)/Quest(Clone)"));
            audioSource.volume = 0.2f;
            audioSource.PlayOneShot(audioClip);
            questInv.Container.Clear();
            giveQuest = false;
            questIsActive = false;
            removeQuest = false;
        }

        else if(questInv.Container.Slots[0].item.Id != current.item.data.Id)
        {
            return;
        }
    }
}
