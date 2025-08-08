using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : BaseUI
{
    [SerializeField] GameObject SlotBG;
    [SerializeField] Button useButton;
    [SerializeField] Button equipButton;
    [SerializeField] Button unequipButton;
    [SerializeField] TextMeshProUGUI itemNameText;
    [SerializeField] TextMeshProUGUI itemDescriptionText;

    List<Slot> SlotList=new List<Slot>(); 
   
    List<Item> InventoryList=new List<Item>();

    public override UIState State => UIState.InventoryUI;

    public override void Init()
    {
        SlotList = SlotBG.GetComponentsInChildren<Slot>(true).ToList();
        foreach (Slot slot in SlotList)
        {
            slot.Init();
        }
    }

    
    public void AddInventory(Item item)
    {

        if(!item.itemdata.IsStackable)
        {
            
            FindEmptySlot(item);
        }
        else
        {
            FindStack(item);
        }
        
    }
        
    void FindStack(Item item)
    {
        for(int i = 0; i < SlotList.Count; i++)
        {
            if (item == SlotList[i])
            {
                
                SlotList[i].quantity++;
                PutItem(SlotList[i], item);
                break;
            }
        }
       
    }
    void FindEmptySlot(Item item)
    {
        
        for (int i = 0; i < SlotList.Count; i++)
        {
            if(SlotList[i].IsEmpty)
            {
                PutItem(SlotList[i],item);
                Debug.Log("아이템 넣기");
                break;
            }
        }
    }

    void PutItem(Slot slot,Item item)
    {
        
        slot.Slotitem= item;
        slot.SetSlot();
        itemNameText.text = item.itemdata.name;
        itemDescriptionText.text = item.itemdata.description;
    }

    void PressEquipButton()
    {

    }

    void PressUnEquipButton()
    {

    }
   
}
