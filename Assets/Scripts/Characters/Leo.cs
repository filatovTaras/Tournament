using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leo : Character
{
    [SerializeField]
    private float highComboFirstHitDamage;
    [SerializeField]
    private float highComboSecondHitDamage;
    [SerializeField]
    private float highComboThirdHitDamage;
    [SerializeField]
    private float lowComboFirstHitDamage;
    [SerializeField]
    private float lowComboSecondHitDamage;
    [SerializeField]
    private float lowComboThirdHitDamage;

    private new void Start()
    {
        base.Start();
    }

    public void HighComboFirstHit(string hitReaction)
    {
        RightHandHD.ActivateDetector(hitReaction, highComboFirstHitDamage);
    }

    public void HighComboFirstHitEnd()
    {
        RightHandHD.DeactivateDetector();
    }

    public void HighComboSecondHit(string hitReaction)
    {
        LeftHandHD.ActivateDetector(hitReaction, highComboSecondHitDamage);
    }

    public void HighComboSecondHitEnd()
    {
        LeftHandHD.DeactivateDetector();
    }

    public void HighComboThirdHit(string hitReaction)
    {
        RightHandHD.ActivateDetector(hitReaction, highComboThirdHitDamage);
    }

    public void HighComboThirdHitEnd()
    {
        RightHandHD.DeactivateDetector();
    }

    public void LowComboFirstHit(string hitReaction)
    {
        LeftFootHD.ActivateDetector(hitReaction, lowComboFirstHitDamage);
    }

    public void LowComboFirstHitEnd()
    {
        LeftFootHD.DeactivateDetector();
    }

    public void LowComboSecondHit(string hitReaction)
    {
        RightFootHD.ActivateDetector(hitReaction, lowComboSecondHitDamage);
    }

    public void LowComboSecondHitEnd()
    {
        RightFootHD.DeactivateDetector();
    }

    public void LowComboThirdHit(string hitReaction)
    {
        LeftFootHD.ActivateDetector(hitReaction, lowComboThirdHitDamage);
    }

    public void LowComboThirdHitEnd()
    {
        LeftFootHD.DeactivateDetector();
    }
}
