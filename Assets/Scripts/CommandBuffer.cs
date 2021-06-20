using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandBuffer : MonoBehaviour
{
    private List<int> buffer = new List<int>();

    private Animator animator;

    private int currentBufferIndex = 0;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("Не найден компонент Animator");
        }
    }

    public void AddCommandToBuffer(int command)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Block"))
        {
            return;
        }

        buffer.Add(command);

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && !animator.IsInTransition(0))
        {
            TrySetNextAnimatorParameter();
        }
    }

    private int GetCommandFromBuffer()
    {
        if (currentBufferIndex >= buffer.Count)
        {
            return 0;
        }

        currentBufferIndex++;

        return buffer[currentBufferIndex - 1];
    }

    public void TrySetNextAnimatorParameter()
    {
        int command = GetCommandFromBuffer();

        if (command == 0)
        {
            return;
        }

        if(command == AnimatorParameters.s_lowCombo || command == AnimatorParameters.s_highCombo)
        {
            AddComboToAnimParameter(command);
            return;
        }

        ChangeBoolAnimParameter(command);
    }

    private void AddComboToAnimParameter(int animatorParameter)
    {
        int comboCount = animator.GetInteger(animatorParameter);
        comboCount++;
        animator.SetInteger(animatorParameter, comboCount);
    }

    private void ChangeBoolAnimParameter(int animatorParameter)
    {
        bool value = animator.GetBool(animatorParameter);
        animator.SetBool(animatorParameter, !value);
    }

    public void ClearAnimatorParameters()
    {
        animator.SetInteger(AnimatorParameters.s_highCombo, 0);
        animator.SetInteger(AnimatorParameters.s_lowCombo, 0);
        animator.SetBool(AnimatorParameters.s_Special1, false);
        animator.SetBool(AnimatorParameters.s_Special2, false);
        animator.SetBool(AnimatorParameters.s_Special3, false);

        buffer.Clear();
        currentBufferIndex = 0;
    }
}
