using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIState
{
    GameUI,
    InventoryUI,
    InteractionUI


}
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;


    public GameUI gameUI;
    public InventoryUI inventoryUI;
    public InteractionUI interactionUI;



    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameUI = GetComponentInChildren<GameUI>(true); 
        inventoryUI = GetComponentInChildren<InventoryUI>(true);
        inventoryUI.Init();
        interactionUI = GetComponentInChildren<InteractionUI>(true);
    }

    
    public void ChangeUI(UIState state,bool on)
    {
        if(state==UIState.GameUI)
        {

        }
        else if (state==UIState.InteractionUI)
        {
            interactionUI.gameObject.SetActive(on);
        }
        else if(state==UIState.InventoryUI)
        {
            inventoryUI.gameObject.SetActive(on);
        }
    }
}
