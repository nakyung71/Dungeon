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
        return "호박 열쇠 3개를 가지고 와야 열 수 있다";
    }

    public string ShowName()
    {
        return "공동묘지 문";
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
        return "E를 통해 문을 열 수 있습니다 ( 호박 열쇠 3개 필요 )";
    }
}

    
  
