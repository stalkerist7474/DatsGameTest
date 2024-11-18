using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGetCoin : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PressButtonGetCoin()
    {
        EventBus.RaiseEvent(new PressGetButtonEvent());
    }
}
