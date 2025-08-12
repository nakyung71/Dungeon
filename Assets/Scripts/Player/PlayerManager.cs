using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public Player player;
    public PlayerInput playerInput;
    public PlayerInteraction playerInteraction;
    public PlayerInventory playerInventory;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
