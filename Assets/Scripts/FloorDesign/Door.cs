using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Door : MonoBehaviour, IInteractable
{
    private bool IsLeftOpen;
    private bool IsRightOpen;
    enum DoorDirection
    {
        Left, 
        Right
    }
    [SerializeField] DoorDirection doorDirection;
    public void Interact()
    {
        if(UIManager.Instance.inventoryUI.LookForKey())
        {
            Open();
        }
        else
        {

        }
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
        if (doorDirection == DoorDirection.Left && IsLeftOpen == false)
        {
            transform.Rotate(0, -90f, 0);
            IsLeftOpen = true;
        }
        else if (doorDirection == DoorDirection.Left && IsLeftOpen == true)
        {
            transform.Rotate(0, 90f, 0);
            IsLeftOpen = false;
        }
        else if(doorDirection == DoorDirection.Right && IsRightOpen == false) 
        {
            transform.Rotate(0, 90f, 0);
            IsRightOpen = true;
        }
        else
        {
            transform.Rotate(0, -90f, 0);
            IsRightOpen = false;
        }
           
    }

    public string ShowInteractionPhase()
    {
        return "E�� ���� ���� �� �� �ֽ��ϴ� ( ȣ�� ���� 3�� �ʿ� )";
    }
}

    
  
