using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IInteractable
{
    string ShowName();
    string ShowDescription();
    string ShowInteractionPhase();
    void Interact();


}



public class Item : MonoBehaviour, IInteractable
{

    public ItemData itemdata;
    public void Interact()
    {
        ItemData loadedItem= DataManager.instance.GetItemInfo(this.itemdata.name);
        UIManager.Instance.inventoryUI.AddInventory(loadedItem);
        if(gameObject!=null)
        {
            Destroy(this.gameObject);
        }
       
        
        
        
    }

    public string ShowDescription()
    {
        return itemdata.description;
    }

    public string ShowInteractionPhase()
    {
        return itemdata.interactPhrase;
    }

    public string ShowName()
    {
        return itemdata.name;
    }
}
