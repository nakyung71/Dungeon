using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    public abstract UIState State { get;}

    public virtual void Init()
    {
        
    }
    public UIState GetUIState()
    {
        return State;
    }

}
