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

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("Не найден компонент Animator");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(forwardKeyCode))
        {
            animator.SetBool(AnimatorParameters.s_forward, true);
        }

        if (Input.GetKeyUp(forwardKeyCode))
        {
            animator.SetBool(AnimatorParameters.s_forward, false);
        }

        if (Input.GetKeyDown(backKeyCode))
        {
            animator.SetBool(AnimatorParameters.s_back, true);
        }

        if (Input.GetKeyUp(backKeyCode))
        {
            animator.SetBool(AnimatorParameters.s_back, false);
        }

        if (Input.GetKeyDown(blockKeyCode))
        {
            animator.SetBool(AnimatorParameters.s_block, true);
        }

        if (Input.GetKeyUp(blockKeyCode))
        {
            animator.SetBool(AnimatorParameters.s_block, false);
        }

        if (Input.GetKeyDown(highComboKeyCode))
        {
            AddComboToAnimParameter(AnimatorParameters.s_highCombo);
        }

        if (Input.GetKeyDown(lowComboKeyCode))
        {
            AddComboToAnimParameter(AnimatorParameters.s_lowCombo);
        }
    }

    private void AddComboToAnimParameter(int animatorParameter)
    {
        int comboCount = animator.GetInteger(animatorParameter);
        comboCount++;
        animator.SetInteger(animatorParameter, comboCount);
    }
}
