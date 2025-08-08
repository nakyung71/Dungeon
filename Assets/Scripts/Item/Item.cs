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
        Debug.Log("상호작용");
        UIManager.Instance.inventoryUI.AddInventory(this);
        Destroy(gameObject);
        
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
