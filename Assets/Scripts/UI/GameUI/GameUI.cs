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
    public Image damageIndicator;
    Coroutine currentCoroutine;
    Color damageIndicatorColor;
    public GameObject witchVision;


    private float duration = 1f;
    private float elapsedTime = 0f;
    private void Start()
    {
        buffBar = GetComponentInChildren<BuffBar>();
        PlayerManager.instance.player.OnChangeHealth += UpdateHealthBar;
        PlayerManager.instance.player.OnChangeHealth += TurnOnDamageIndicator;
        damageIndicatorColor=damageIndicator.color;
    }

    void UpdateHealthBar(float health)
    {
        rectTransform.sizeDelta = new Vector2((health/100f)*300f, 45f);
        Debug.Log(health);
    }
    
    void TurnOnDamageIndicator(float health)
    {
        damageIndicator.enabled = true;
        currentCoroutine=StartCoroutine(DamageIndicator());
    }


    IEnumerator DamageIndicator()
    {
        elapsedTime = 0;
        while(elapsedTime<duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            damageIndicatorColor.a = Mathf.Lerp(1, 0, t);
            damageIndicator.color = damageIndicatorColor;
            yield return null;
        }
        damageIndicator.enabled = false;
        currentCoroutine = null;

    }

}
