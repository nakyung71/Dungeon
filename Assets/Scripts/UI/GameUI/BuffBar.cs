using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffBar : MonoBehaviour
{
    [SerializeField] GameObject buffSlot;
    Image slotImage;

    public void SetBuffIcon(ItemData item)
    {
        GameObject go = Instantiate(buffSlot, transform);
        slotImage= go.GetComponent<Image>();
        slotImage.sprite=item.itemIcon;
        slotImage.gameObject.SetActive(true);
        StartCoroutine(IconBlink());
    }

    private IEnumerator IconBlink()
    {
        yield return new WaitForSeconds(15f);
        float blinktime = 5f;
        float elapsedTIme = 0f;
        
        while (elapsedTIme < blinktime)
        {
           
            slotImage.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.25f);
            slotImage.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.25f);
            elapsedTIme += 0.5f;
        }
        slotImage.gameObject.SetActive(false);

    }

}
