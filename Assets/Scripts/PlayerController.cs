using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode forwardKeyCode = KeyCode.D;
    [SerializeField]
    private KeyCode backKeyCode = KeyCode.A;

    private Animator animator;

    static readonly int s_forwardParameterHash = Animator.StringToHash("Forward");
    static readonly int s_backParameterHash = Animator.StringToHash("Back");

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(forwardKeyCode))
        {
            animator.SetBool(s_forwardParameterHash, true);
        }

        if (Input.GetKeyUp(forwardKeyCode))
        {
            animator.SetBool(s_forwardParameterHash, false);
        }

        if (Input.GetKeyDown(backKeyCode))
        {
            animator.SetBool(s_backParameterHash, true);
        }

        if (Input.GetKeyUp(backKeyCode))
        {
            animator.SetBool(s_backParameterHash, false);
        }
    }
}
