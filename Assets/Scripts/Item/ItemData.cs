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
public class ItemData : ScriptableObject
{
    public string itemName;
    public string description;
    public ItemType itemType;
    public bool IsStackable;
    public Sprite itemIcon;
    public GameObject itemPrefab;

    
}
