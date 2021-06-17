using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandBuffer : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("Не найден компонент Animator");
        }
    }

    public void ClearAnimatorParameters()
    {
        animator.SetInteger(AnimatorParameters.s_highCombo, 0);
    }
}
