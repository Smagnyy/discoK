using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopWindow : MonoBehaviour
{
    public static ShopWindow Instance;
    public SlotInShopDATA[] arrayOfAvailableSlots;
    public List<SlotInShop> slotsInShop;

    public GameObject shopGO;

    int availableSlotsForBuy = 2;


    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        arrayOfAvailableSlots = Resources.LoadAll<SlotInShopDATA>("ScriptableObjects/SlotsInShop");
        foreach (var item in slotsInShop)
        {
            item.gameObject.SetActive(false);
        }
        
        CloseShop();
    }

   
    public void OpenShop()
    {
        shopGO.SetActive(true);
        for (int i = 0; i < availableSlotsForBuy; i++)
        {
            slotsInShop[i].gameObject.SetActive(true);
            slotsInShop[i].ShowSlot(arrayOfAvailableSlots[Random.Range(0,arrayOfAvailableSlots.Length)]);
        }
    }

    public void CloseShop()
    {
        shopGO.SetActive(false);
    }
}
