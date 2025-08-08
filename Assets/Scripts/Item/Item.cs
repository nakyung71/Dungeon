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
        Debug.Log("��ȣ�ۿ�");
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
