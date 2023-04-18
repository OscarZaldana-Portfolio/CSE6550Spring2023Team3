using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SetButtonsOn : MonoBehaviour
{
    public UnityEvent onEndAnimation;
    public void SetButtonsBack()
    {
        onEndAnimation.Invoke();
    }
}
