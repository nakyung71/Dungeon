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
        return "ȣ�� ���� 3���� ������ �;� �� �� �ִ�";
    }

    public string ShowName()
    {
        return "�������� ��";
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

    
  
