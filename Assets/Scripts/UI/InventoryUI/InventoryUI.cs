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
    [SerializeField] Button useButton;
    [SerializeField] Button equipButton;
    [SerializeField] Button unEquipButton;
    [SerializeField] Button discardButton;
    [SerializeField] TextMeshProUGUI itemNameText;
    [SerializeField] TextMeshProUGUI itemDescriptionText;

  

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
        useButton.onClick.AddListener(PressUseButton);
        discardButton.onClick.AddListener(PressDiscardButton);
        unEquipButton.onClick.AddListener(PressUnEquipButton);
        
    }

    private void OnEnable()
    {
        unEquipButton.gameObject.SetActive(false);
        equipButton.gameObject.SetActive(false);
        useButton.gameObject.SetActive(false);
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




    void PressUseButton()
    {
        PlayerManager.instance.player.UseItem(selectedSlot.Slotitem);

        selectedSlot.ChangeQuantity(-1);
    }
    void ChangeButtonStatus(Slot slot)
    {
        if(slot.Slotitem.itemType==ItemType.Potions)
        {
            useButton.gameObject.SetActive(true);
            equipButton.gameObject.SetActive(false);
            unEquipButton.gameObject.SetActive(false);
        }
        else if((slot.Slotitem.itemType==ItemType.Equipment||slot.Slotitem.itemType==ItemType.VisionChange)&&slot.IsEquipped)
        {
            useButton.gameObject.SetActive(false);
            equipButton.gameObject.SetActive(false);
            unEquipButton.gameObject.SetActive(true);
        }
        else if ((slot.Slotitem.itemType == ItemType.Equipment || slot.Slotitem.itemType == ItemType.VisionChange) && slot.IsEquipped==false)
        {
            useButton.gameObject.SetActive(false);
            equipButton.gameObject.SetActive(true);
            unEquipButton.gameObject.SetActive(false);
        }
        else
        {
            useButton.gameObject.SetActive(false);
            equipButton.gameObject.SetActive(false);
            unEquipButton.gameObject.SetActive(false);
        }
    }


    void PressEquipButton()
    {
        
        
        if (selectedSlot.Slotitem.itemType == ItemType.Equipment)
        {
            PlayerManager.instance.player.Equip(selectedSlot.Slotitem);
            selectedSlot.IsEquipped=true;
            ChangeButtonStatus(selectedSlot);
        }
        else if(selectedSlot.Slotitem.itemType==ItemType.VisionChange)
        {
            PlayerManager.instance.player.ChangeVision(true);
            selectedSlot.IsEquipped = true;
            ChangeButtonStatus(selectedSlot);
        }
    }

    void PressUnEquipButton()
    {
        if (selectedSlot.Slotitem.itemType == ItemType.Equipment)
        {
            PlayerManager.instance.player.UnEquip(selectedSlot.Slotitem);
            selectedSlot.IsEquipped = false;
            ChangeButtonStatus (selectedSlot);
        }
        else if (selectedSlot.Slotitem.itemType == ItemType.VisionChange)
        {
            PlayerManager.instance.player.ChangeVision(false);
            selectedSlot.IsEquipped = false;
            ChangeButtonStatus(selectedSlot);
        }
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
        ChangeButtonStatus(slot);
        
    }

    public bool LookForKey()
    {
        foreach(Slot slot in SlotList)
        {
            if(slot.Slotitem==null)
            {
                continue;
            }
            if (slot.Slotitem.itemType == ItemType.Key)
            {
                if (slot.Quantity >= 3)
                {
                    return true;
                    
                }
                else
                {
                    return false;
                }
            }

        }
        return false;
    }

    
   
}
