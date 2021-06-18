using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private CapsuleCollider[] hurtBoxesArray = new CapsuleCollider[5];

    [SerializeField]
    private HitDetector RightHandHD;
    [SerializeField]
    private HitDetector LeftHandHD;
    [SerializeField]
    private HitDetector RightFootHD;
    [SerializeField]
    private HitDetector LeftFootHD;
    [SerializeField] // Сериалайз для тестов
    private HitDetector ActualHitDetector = null;

    private SphereCollider RightHandCollider;
    private SphereCollider LeftHandCollider;
    private SphereCollider RightFootCollider;
    private SphereCollider LeftFootCollider;
    private SphereCollider ActualCollider;

    private Animator Animator;

    private readonly LayerMask playerHitBoxLayer = 10;
    private readonly LayerMask playerHurtBoxLayer = 11;
    private readonly LayerMask enemyHitBoxLayer = 12;
    private readonly LayerMask enemyHurtBoxLayer = 13;

    [SerializeField]
    private bool isPlayer = false; // Для тестов

    void Start()
    {
        Animator = GetComponent<Animator>();

        RightHandCollider = RightHandHD.gameObject.GetComponent<SphereCollider>();
        LeftHandCollider =  LeftHandHD.gameObject.GetComponent<SphereCollider>();
        RightFootCollider = RightFootHD.gameObject.GetComponent<SphereCollider>();
        LeftFootCollider = LeftFootHD.gameObject.GetComponent<SphereCollider>();

        SetLayersOnColliders(enemyHitBoxLayer, enemyHurtBoxLayer);
        
        if (isPlayer) SetIsPlayer(); //для тестов

    }

    public void SetIsPlayer()
    {
        SetLayersOnColliders(playerHitBoxLayer, playerHurtBoxLayer);
        gameObject.AddComponent<PlayerController>();
    }

    private void SetLayersOnColliders(LayerMask hitBoxLayerMask, LayerMask hurtBoxLayerMask)
    {
        RightHandHD.gameObject.layer = hitBoxLayerMask;
        LeftHandHD.gameObject.layer = hitBoxLayerMask;
        RightFootHD.gameObject.layer = hitBoxLayerMask;
        LeftFootHD.gameObject.layer = hitBoxLayerMask;

        foreach(CapsuleCollider hurtBox in hurtBoxesArray)
        {
            hurtBox.gameObject.layer = hurtBoxLayerMask;
        }
    }

    public void Hit(string takeHitReaction)
    {
        Character target = ActualHitDetector.GetCharacterHitted();

        if (target == null) return;

        target.TakeDamage(takeHitReaction);

        ActualHitDetector.ResetCharacterHitted();
        ActualCollider.enabled = false;
        ActualHitDetector = null;
        ActualCollider = null;
    }

    public void TakeDamage(string takeHitReaction)
    {
        int takeHitReactionHash = Animator.StringToHash(takeHitReaction);
        Animator.SetTrigger(takeHitReactionHash);
    }

    public void SetRightHandActualHitDetector()
    {
        SetCurrentHitComponents(RightHandHD, RightHandCollider);
    }

    public void SetLeftHandActualHitDetector()
    {
        SetCurrentHitComponents(LeftHandHD, LeftHandCollider);
    }

    public void SetRightFootActualHitDetector()
    {
        SetCurrentHitComponents(RightFootHD, RightFootCollider);
    }

    public void SetLeftFootActualHitDetector()
    {
        SetCurrentHitComponents(LeftFootHD, LeftFootCollider);
    }

    private void SetCurrentHitComponents(HitDetector hitDetector, SphereCollider hitCollider)
    {
        ActualHitDetector = hitDetector;
        ActualCollider = hitCollider;
        ActualCollider.enabled = true;
    }
}
