using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct CraftingRecipes
{
    public ItemObject result;
    public Item[] itemObject;
    public int[] Id;
}

[CreateAssetMenu]
public class NewBehaviourScript : ScriptableObject
{
    public CraftingRecipes[] craftingRecipesNew;
}
