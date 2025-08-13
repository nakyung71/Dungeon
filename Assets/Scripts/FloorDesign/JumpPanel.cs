using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPanel : MonoBehaviour
{

    Rigidbody rb;
    float jumpPanelForce = 50f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {

            rb=other.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up*jumpPanelForce,ForceMode.Impulse);
            other.GetComponent<Player>()?.ChangeHealth(-5f);
        }
    }
}
