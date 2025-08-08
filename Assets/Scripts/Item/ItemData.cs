using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public enum ItemType
{
    Key,
    Potions,
    Equipment,
    Normal

}

[CreateAssetMenu(fileName = "ItemData", menuName = "ItemSO")]
public class ItemData : ScriptableObject, IInteractable
{
    public string itemName;
    public string description;
    public ItemType itemType;
    public Sprite itemIcon;
    public GameObject itemPrefab;

    public void Interact()
    {
        //인벤토리에 넣기
    }

    public string ShowDescription()
    {
        return description;
    }

    public string ShowName()
    {
        return name;
       
    }
}
