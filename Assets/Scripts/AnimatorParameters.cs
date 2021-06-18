using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorParameters : MonoBehaviour
{
    public static readonly int s_forward = Animator.StringToHash("Forward");
    public static readonly int s_back = Animator.StringToHash("Back");
    public static readonly int s_block = Animator.StringToHash("isBlocking");
    public static readonly int s_highCombo = Animator.StringToHash("HighCombo");
    public static readonly int s_lowCombo = Animator.StringToHash("LowCombo");
    public static readonly int s_pHighFrontWeak = Animator.StringToHash("pHighFrontWeak"); 
    public static readonly int s_mHighLeftMed = Animator.StringToHash("mHighLeftMed");
    public static readonly int s_pHighUpperWeak = Animator.StringToHash("pHighUpperWeak"); 
    public static readonly int s_pLowLeftWeak = Animator.StringToHash("pLowLeftWeak"); 
    public static readonly int s_mMidRightWeak = Animator.StringToHash("mMidRightWeak"); 
    public static readonly int s_HighKOAir = Animator.StringToHash("HighKOAir"); 
}
