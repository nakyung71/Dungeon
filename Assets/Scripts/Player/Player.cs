using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private void Awake()
    {
        PlayerManager.instance.player = this;
    }
    private float _health = 100f;
    public float Health
    {
        get { return _health; }
        set 
        { 
            _health=Mathf.Clamp(value,0,100f);
            
        }
    }
    private float _stamina;
    public float Stamina
    {
        get { return _stamina; }
        set { _stamina = Mathf.Clamp(value, 0, 100f); }
    }

    private float _speed = 5f;
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
    [SerializeField] Transform cameraContainer;

    Vector3 equipPosition = new Vector3(0.6f, -0.7f, 1f);
    public Action<float> OnChangeHealth;

    
    public void Equip(ItemData item)
    {
        GameObject go = Instantiate(item.equipPrefab, cameraContainer);
        go.transform.localPosition = equipPosition;

    }

    public void UseItem(ItemData item)
    {
        if(item.valueType==ValueType.Health)
        {
            ChangeHealth(item.value);
        }
        else if(item.valueType==ValueType.Stamina)
        {
            ChangeStamina(item.value);
        }
        else
        {
            ChangeSpeed(item.value);
            UIManager.Instance.gameUI.buffBar.SetBuffIcon(item);
        }
    }
    public void ChangeHealth(float health)
    {
        Health += health;
        OnChangeHealth?.Invoke(Health);
    }
    public void ChangeStamina(float stamina)
    {
        Stamina += stamina;
    }
    public void ChangeSpeed(float speed)
    {
        Speed += speed;
        StartCoroutine(PotionEffect(speed));
    }


    //public  Action OnBuffDisappear;
    private IEnumerator PotionEffect(float speed)
    {

        yield return new WaitForSeconds(20f);
        //그냥 끄는거면 그냥 여기에 델리게이트 이벤트 달든 해서 끄면 됨
        //근데 5초전에도 알려주고싶어 깜빡이게
        //OnBuffDisappear?.Invoke();

        ChangeSpeed(-speed);
        
    }
}
