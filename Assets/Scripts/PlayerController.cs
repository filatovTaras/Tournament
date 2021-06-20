using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode forwardKeyCode = KeyCode.D;
    [SerializeField]
    private KeyCode backKeyCode = KeyCode.A;
    [SerializeField]
    private KeyCode blockKeyCode = KeyCode.Space;
    [SerializeField]
    private KeyCode highComboKeyCode = KeyCode.U;
    [SerializeField]
    private KeyCode lowComboKeyCode = KeyCode.I;
    [SerializeField]
    private KeyCode special1 = KeyCode.Alpha1;
    [SerializeField]
    private KeyCode special2 = KeyCode.Alpha2;
    [SerializeField]
    private KeyCode special3 = KeyCode.Alpha3;

    private CommandBuffer commandBuffer;

    private Animator animator;

    void Start()
    {
        commandBuffer = GetComponent<CommandBuffer>();
        animator = GetComponent<Animator>();

        if (commandBuffer == null)
        {
            Debug.LogError("Не найден компонент CommandBuffer");
        }

        if(animator == null)
        {
            Debug.Log("Не найден компонент Animator");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(forwardKeyCode))
        {
            animator.SetBool(AnimatorParameters.s_forward, true);
        }
        else if (Input.GetKeyUp(forwardKeyCode))
        {
            animator.SetBool(AnimatorParameters.s_forward, false);
        }
        else if (Input.GetKeyDown(backKeyCode))
        {
            animator.SetBool(AnimatorParameters.s_back, true);
        }
        else if (Input.GetKeyUp(backKeyCode))
        {
            animator.SetBool(AnimatorParameters.s_back, false);
        }
        else if (Input.GetKeyDown(blockKeyCode))
        {
            animator.SetBool(AnimatorParameters.s_block, true);
        }
        else if (Input.GetKeyUp(blockKeyCode))
        {
            animator.SetBool(AnimatorParameters.s_block, false);
        }
        else if (Input.GetKeyDown(highComboKeyCode))
        {
            commandBuffer.AddCommandToBuffer(AnimatorParameters.s_highCombo);
        }
        else if (Input.GetKeyDown(lowComboKeyCode))
        {
            commandBuffer.AddCommandToBuffer(AnimatorParameters.s_lowCombo);
        }
        else if (Input.GetKeyDown(special1))
        {
            commandBuffer.AddCommandToBuffer(AnimatorParameters.s_Special1);
        }
        else if (Input.GetKeyDown(special2))
        {
            commandBuffer.AddCommandToBuffer(AnimatorParameters.s_Special2);
        }
        else if (Input.GetKeyDown(special3))
        {
            commandBuffer.AddCommandToBuffer(AnimatorParameters.s_Special3);
        }
    }
}
