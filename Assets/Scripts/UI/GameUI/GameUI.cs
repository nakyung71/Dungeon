using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
   public BuffBar buffBar;

    private void Start()
    {
        buffBar = GetComponentInChildren<BuffBar>();
    }
}
