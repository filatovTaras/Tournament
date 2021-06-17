using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorParameters : MonoBehaviour
{
    public static readonly int s_forward = Animator.StringToHash("Forward");
    public static readonly int s_back = Animator.StringToHash("Back");
    public static readonly int s_block = Animator.StringToHash("isBlocking");
    public static readonly int s_highCombo = Animator.StringToHash("HighCombo");
}
