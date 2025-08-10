using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IInteractable
{
    string ShowName();
    string ShowDescription();
    void Interact();


}



public class Item : MonoBehaviour, IInteractable
{

    public ItemData itemdata;
    public void Interact()
    {
        ItemData loadedItem= DataManager.instance.GetItemInfo(this.itemdata.name);
        UIManager.Instance.inventoryUI.AddInventory(loadedItem);
        
        Destroy(this.gameObject);
        
        
        
    }

    public string ShowDescription()
    {
        return itemdata.description;
    }

    public string ShowName()
    {
        return itemdata.name;
    }
}
