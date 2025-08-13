using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;

public class Slot : MonoBehaviour,IPointerClickHandler
{
    public bool IsEmpty { get; private set; } = true;
    public int Quantity { get; private set; } = 0;
    public ItemData Slotitem {  get; private set; }

 
    private Image image;
    [SerializeField] Sprite emptyImage;
    private Outline outline;
    private TextMeshProUGUI quantityText;


    public static event Action<Slot> OnSlotClick;
    public void Init()
    {
        foreach(Transform child in transform)
        {
            
            if(child.GetComponent<Image>() != null)
            {
                image = child.GetComponent<Image>();
    
            }
        }
        outline=GetComponentInChildren<Outline>();
        
        quantityText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetSlot(ItemData itemData)
    {
        Slotitem = itemData;
        if(Slotitem == null)
        {
            Debug.Log("ΩΩ∑‘æ∆¿Ã≈€ NUll");
        }
        
        IsEmpty = false;
        image.sprite = itemData.itemIcon;
        Quantity++;
        quantityText.text=Quantity.ToString(); 
        
    }

    public void DiscardSlotItems()
    {
        IsEmpty = true;
        Slotitem = null;
        image.sprite = emptyImage;
        Quantity = 0;
        outline.enabled = false;
        Debug.Log(Quantity.ToString());
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(Slotitem==null)
        {
            return;
        }
        OnSlotClick?.Invoke(this);
        
       
    }

    public void ChangeOutlineState(bool on)
    {
        outline.enabled = on;
    }

    public void ChangeQuantity(int quantity)
    {
        Quantity += quantity;
        if(Quantity==0)
        {
            DiscardSlotItems();
        }
        quantityText.text = Quantity.ToString();
    }

    public ItemType GetTypeOfItem()
    {
        return Slotitem.itemType;
    }

}
