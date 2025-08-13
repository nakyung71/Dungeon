using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class InventoryUI : BaseUI
{
    [SerializeField] GameObject SlotBG;
    [SerializeField] Button equipButton;
    [SerializeField] Button discardButton;
    [SerializeField] TextMeshProUGUI itemNameText;
    [SerializeField] TextMeshProUGUI itemDescriptionText;
    [SerializeField] TextMeshProUGUI equipButtonText;
  

    List<Slot> SlotList=new List<Slot>();

    Slot selectedSlot;
    private bool isFoundSlot;
    public override UIState State => UIState.InventoryUI;

    public override void Init()
    {
        SlotList = SlotBG.GetComponentsInChildren<Slot>(true).ToList();
        foreach (Slot slot in SlotList)
        {
            slot.Init();
        }
        Slot.OnSlotClick += OnClickUI;
        equipButton.onClick.AddListener(PressEquipButton);
        discardButton.onClick.AddListener(PressDiscardButton);
        
    }

    
    public void AddInventory(ItemData itemData)
    {

        if(!itemData.IsStackable)
        {
            
            FindEmptySlot(itemData);
        }
        else
        {
            FindStack(itemData);
        }
        
    }
        
    void FindStack(ItemData itemData)
    {
        isFoundSlot = false;
        for(int i = 0; i < SlotList.Count; i++)
        {
            if (itemData == SlotList[i].Slotitem)
            {
                
                //SlotList[i].quantity++;
                PutItem(SlotList[i], itemData);
                isFoundSlot=true;
                break;
            }
        }
        if(!isFoundSlot)
        {
            FindEmptySlot(itemData);
        }
        
       
    }
    void FindEmptySlot(ItemData itemData)
    {
        
        for (int i = 0; i < SlotList.Count; i++)
        {
            if(SlotList[i].IsEmpty)
            {
                PutItem(SlotList[i],itemData);
                break;
            }
        }
    }

    void PutItem(Slot slot,ItemData itemData)
    {
       
        
        slot.SetSlot(itemData);
        
    }

    void PressEquipButton()
    {
        
        if (selectedSlot.Slotitem.itemType == ItemType.Potions)
        {
            PlayerManager.instance.player.UseItem(selectedSlot.Slotitem);

            selectedSlot.ChangeQuantity(-1);
           
        }
        else if (selectedSlot.Slotitem.itemType == ItemType.Equipment)
        {
            PlayerManager.instance.player.Equip(selectedSlot.Slotitem);
        }
        else if(selectedSlot.Slotitem.itemType==ItemType.VisionChange)
        {
            PlayerManager.instance.player.ChangeVision(true);
        }
    }

    void PressUnEquipButton()
    {

    }

    void PressDiscardButton()
    {
        GameObject go= Instantiate(selectedSlot.Slotitem.itemPrefab);
        go.transform.position = PlayerManager.instance.player.transform.position + PlayerManager.instance.player.transform.forward * 1f;
        selectedSlot.DiscardSlotItems();
        
    }

    void OnClickUI(Slot slot)
    {
        if(slot!=selectedSlot&& selectedSlot != null)
        {

            selectedSlot.ChangeOutlineState(false);


        }
           
        selectedSlot = slot;
        slot.ChangeOutlineState(true);
        itemNameText.text = slot.Slotitem.itemName;
        itemDescriptionText.text = slot.Slotitem.description;
        discardButton.gameObject.SetActive(true);

        ItemType type= slot.GetTypeOfItem(); 
        if(type==ItemType.Normal||type==ItemType.Key)
        {
            equipButton.gameObject.SetActive(false);
            
        }
        else if(type==ItemType.Potions)
        {
            equipButton.gameObject.SetActive(true);
            equipButtonText.text = "Use";
        }
        else if(type==ItemType.Equipment||type==ItemType.VisionChange)
        {
            equipButton.gameObject.SetActive(true);
            equipButtonText.text = "Equip";
        }
        
    }

    
   
}
