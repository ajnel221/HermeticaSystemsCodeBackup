using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (fileName = "New Quest", menuName = "Quest System/Quest")]
public class QuestObject : ScriptableObject
{
    public string questDescription;
    public GameObject questText;
    public ItemObject item;
    public int goldToGive;
    public AudioClip questSound;
}
