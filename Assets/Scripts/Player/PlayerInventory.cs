using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    List<Item> InventoryList=new List<Item>();
    private void Awake()
    {
        PlayerManager.instance.playerInventory = this;
    }
}
