using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewSlotInShop", menuName = "ScriptableObjects/CreateNewSLotForShop", order = 0)]
public class SlotInShopDATA : ScriptableObject
{
    
    public Sprite labelImage;
    public string slotName;
    public string description;

    public int cost;
}
