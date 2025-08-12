using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
   public BuffBar buffBar;

    public GameObject healthBar;
    public GameObject staminaBar;
    public RectTransform rectTransform;

    private void Start()
    {
        buffBar = GetComponentInChildren<BuffBar>();
        PlayerManager.instance.player.OnChangeHealth += UpdateHealthBar;
        
    }

    void UpdateHealthBar(float health)
    {
        rectTransform.sizeDelta = new Vector2((health/100f)*300f, 45f);
        Debug.Log(health);
    }
    

}
