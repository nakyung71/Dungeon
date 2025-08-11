using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    private List<ItemData> dataList = new List<ItemData>();

    public Dictionary<string, ItemData> ItemDataDictionary= new Dictionary<string, ItemData>();
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        dataList = Resources.LoadAll<ItemData>("ScriptableObjects").ToList();

        SetData();
    }

    private void SetData()
    {
        foreach (ItemData item in dataList)
        {
            if(!ItemDataDictionary.ContainsKey(item.itemName))
            {
                ItemDataDictionary.Add(item.itemName, item);
            }
        }

    }

    public ItemData GetItemInfo(string itemName)
    {
        if(ItemDataDictionary.TryGetValue(itemName, out ItemData itemData))
        {
            return itemData;
        }
        else
        {
            return null;
        }
    }
    
}
