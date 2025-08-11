using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Door : MonoBehaviour, IInteractable
{
    enum DoorDirection
    {
        Left, 
        Right
    }
    [SerializeField] DoorDirection doorDirection;
    public void Interact()
    {
        Open();
    }

    public string ShowDescription()
    {
        return "호박 열쇠 3개를 가지고 와야 열 수 있다";
    }

    public string ShowName()
    {
        return "공동묘지 문";
    }

    void Open()
    {
        if(doorDirection == DoorDirection.Left)
        {
            transform.Rotate(0, -90f, 0);
        }
        else
        {
            transform.Rotate(0, 90f, 0);
        }
           
    }

}

    
  
