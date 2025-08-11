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
    
    public void ChangeHealth()
    {

    }
}
