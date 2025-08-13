using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffBar : MonoBehaviour
{
    [SerializeField] GameObject buffSlot;


    
    public void SetBuffIcon(ItemData item)
    {
        GameObject go = Instantiate(buffSlot, transform);
        Image slotImage= go.GetComponent<Image>();
        slotImage.sprite=item.itemIcon;
        go.SetActive(true);
        StartCoroutine(IconBlink(go,slotImage));
    }

    private IEnumerator IconBlink(GameObject go,Image slotImage)
    {
        
        yield return new WaitForSeconds(15f);
        float blinktime = 5f;
        float elapsedTIme = 0f;
        
        while (elapsedTIme < blinktime)
        {
           
            slotImage.enabled = false;
            yield return new WaitForSeconds(0.25f);
            slotImage.enabled = true;
            yield return new WaitForSeconds(0.25f);
            elapsedTIme += 0.5f;
        }
        Destroy(go);

    }

}
