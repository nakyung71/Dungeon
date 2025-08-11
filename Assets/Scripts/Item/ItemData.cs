using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;



public enum ItemType
{
    Key,
    Potions,
    Equipment,
    Normal

}

public enum ValueType
{
    None,
    Health,
    Stamina,
    Speed,
    Attack,
    Defence,

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
    public GameObject equipPrefab;
    public float value;
    public ValueType valueType;

    
}
