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

    ItemData itemdata;
    public void Interact()
    {
       
    }

    public string ShowDescription()
    {
        throw new System.NotImplementedException();
    }

    public string ShowName()
    {
        throw new System.NotImplementedException();
    }
}
