using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchVision : MonoBehaviour
{
    [SerializeField] LayerMask normalLayer;
    [SerializeField] LayerMask trapLayer;
    private void OnEnable()
    {
        Camera.main.cullingMask=trapLayer;

    }

    private void OnDisable()
    {
        Camera.main.cullingMask = normalLayer;
    }
}
