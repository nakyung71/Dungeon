using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    Player player;
    [SerializeField] Transform cameraTransform;
    float rayDistance = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShootRay()
    {
        Ray ray=new Ray();
        RaycastHit hit;
        ray.origin = player.transform.position + Vector3.up;
        ray.direction = player.transform.forward;
        if(Physics.Raycast(ray,out hit,rayDistance))
        {
            IInteractable interactable=hit.collider.GetComponent<IInteractable>();
            if(interactable!=null)
            {
                UIManager.Instance.interactionUI.ShowObjectName(interactable);
                UIManager.Instance.interactionUI.ShowObjectDescription(interactable);
            }
            
        }
    }
}
