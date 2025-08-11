using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _health;
    public float Health
    {
        get { return _health; }
        set { _health = value; }
    }
    private float _stamina;
    public float Stamina
    {
        get { return _stamina; }
        set { _stamina = value; }
    }
    [SerializeField] Transform cameraContainer;

    Vector3 equipPosition = new Vector3(0.6f, -0.7f, 1f);


    private void Start()
    {
        
    }
    public void Equip(ItemData item)
    {
        GameObject go = Instantiate(item.equipPrefab, cameraContainer);
        go.transform.localPosition = equipPosition;

    }
    public void ChangeHealth()
    {

    }
}
