using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InteractionUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI descriptionText;

    // Start is called before the first frame update

    private void OnEnable()
    {
        
    }

    public void ShowObjectName(IInteractable interactable)
    {
        nameText.text = interactable.ShowName();
    }
    public void ShowObjectDescription(IInteractable interactable)
    {
        descriptionText.text = interactable.ShowDescription();
    }
}
