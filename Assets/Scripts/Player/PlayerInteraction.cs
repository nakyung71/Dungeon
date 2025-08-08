using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    
    [SerializeField] Transform cameraTransform;
    [SerializeField] Camera cam;
    float rayDistance = 20f;
    Vector3 cameraMiddle = new Vector3(0.5f, 0.5f, 0f);
    IInteractable lastTriggeredInteractable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootRay();
        if(lastTriggeredInteractable != null&&Input.GetKey(KeyCode.E))
        {
            lastTriggeredInteractable.Interact();
        }
    }

    void ShootRay()
    {
        Ray ray = cam.ViewportPointToRay(cameraMiddle);
        RaycastHit hit;
        
        if(Physics.Raycast(ray,out hit,rayDistance))
        {
            IInteractable interactable=hit.collider.GetComponent<IInteractable>();
            lastTriggeredInteractable = interactable;
            if (interactable!=null)
            {
                
                UIManager.Instance.ChangeUI(UIState.InteractionUI);
                UIManager.Instance.interactionUI.ShowObjectName(interactable);
                UIManager.Instance.interactionUI.ShowObjectDescription(interactable);
                
                
            }
            
        }
    }
}
