using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public bool IsEmpty { get; private set; } = true;
    public int quantity;
    public Item Slotitem;

 
    private Image image;
    private TextMeshProUGUI quantityText;

    public void Init()
    {
        foreach(Transform child in transform)
        {
            
            if(child.GetComponent<Image>() != null)
            {
                image = child.GetComponent<Image>();
            }
        }
        
        quantityText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetSlot()
    {
        IsEmpty = false;
        image.sprite = Slotitem.itemdata.itemIcon;
        quantityText.text=quantity.ToString(); 
    }

    public void DiscardSlotItems()
    {
        IsEmpty = true;
        image.sprite = null;
        quantityText.text = 0.ToString();
    }
}
