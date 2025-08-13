using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostNPC : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        UIManager.Instance.gameUI.happyEnding.SetActive(true);
    }

    public string ShowDescription()
    {
        return "��� ���ۺ��̴� �����̴�";
    }

    public string ShowInteractionPhase()
    {
        return "E�� ���� ���� �ɾ��";
    }

    public string ShowName()
    {
        return "���� ����";
    }
}
