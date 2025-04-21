using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;

public class SlotInShop : MonoBehaviour
{
    SlotInShopDATA dataOfThisSLot;
     public Image labelImage;

     public GameObject coveredViewGO;
     public GameObject uncoveredViewGO;

     public TMP_Text textName;
     public TMP_Text textDescr;

     public TMP_Text textCost;

     public Transform anchorCoveredView;

    // Start is called before the first frame update
    void Start()
    {
        OnEnterRotate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowSlot(SlotInShopDATA _newData)
    {
        dataOfThisSLot = _newData;
        labelImage.sprite = dataOfThisSLot.labelImage;
        textName.text = dataOfThisSLot.slotName;
        textDescr.text = dataOfThisSLot.description;
        textCost.text = "стоимость " + dataOfThisSLot.cost.ToString();
    }

    public void OpenSlot()
    {
        coveredViewGO.SetActive(false);
        uncoveredViewGO.SetActive(true);
    }

    public void CloseSlot()
    {
        coveredViewGO.SetActive(true);
        uncoveredViewGO.SetActive(false);
    }

    public void OnEnterRotate()
    {
        
        float newPoint = Random.Range(-10,11);
        anchorCoveredView.DOLocalRotate(new Vector3(0,0,newPoint), 0.3f);
    }


    public void Buy()
    {
        if(GlobalValues.money < dataOfThisSLot.cost)
        {
            GlobalContentContainer.Instance.CreatePopUpText("не хватает денег", Player.Instance.transform.position);
            //return;
        }
        else if(GlobalValues.money >= dataOfThisSLot.cost)
        {
            
            GlobalValues.money -= dataOfThisSLot.cost;
            UI_main.Instance.UpdateMoneyText();
            Player.Instance.ActionsContainer.AddComponent<WalkStTest>();
            Player.Instance.baseUnit.IniitializeStates();
            gameObject.SetActive(false);
        }
        

    }
}
