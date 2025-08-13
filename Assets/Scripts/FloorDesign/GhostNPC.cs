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
        return "어딘가 슬퍼보이는 유령이다";
    }

    public string ShowInteractionPhase()
    {
        return "E를 눌러 말을 걸어보자";
    }

    public string ShowName()
    {
        return "꼬마 유령";
    }
}
