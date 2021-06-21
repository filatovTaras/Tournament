using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    protected Health health;

    [SerializeField]
    protected CapsuleCollider[] hurtBoxesArray = new CapsuleCollider[5];

    [SerializeField]
    protected HitDetector RightHandHD;
    [SerializeField]
    protected HitDetector LeftHandHD;
    [SerializeField]
    protected HitDetector RightFootHD;
    [SerializeField]
    protected HitDetector LeftFootHD;

    protected SphereCollider RightHandCollider;
    protected SphereCollider LeftHandCollider;
    protected SphereCollider RightFootCollider;
    protected SphereCollider LeftFootCollider;

    protected Animator Animator;

    protected readonly LayerMask playerHitBoxLayer = 10;
    protected readonly LayerMask playerHurtBoxLayer = 11;
    protected readonly LayerMask enemyHitBoxLayer = 12;
    protected readonly LayerMask enemyHurtBoxLayer = 13;
    
    [SerializeField]
    protected bool _isPlayer = false;

    public bool isPlayer
    {
        get
        {
            return _isPlayer;
        }
        set
        {
            _isPlayer = value;
            SetIsPlayer(_isPlayer);
        }
    }

    protected void Start()
    {
        Animator = GetComponent<Animator>();

        RightHandCollider = RightHandHD.gameObject.GetComponent<SphereCollider>();
        LeftHandCollider =  LeftHandHD.gameObject.GetComponent<SphereCollider>();
        RightFootCollider = RightFootHD.gameObject.GetComponent<SphereCollider>();
        LeftFootCollider = LeftFootHD.gameObject.GetComponent<SphereCollider>();

        SetLayersOnColliders(enemyHitBoxLayer, enemyHurtBoxLayer);

        SetIsPlayer(_isPlayer);
    }

    protected void SetIsPlayer(bool value)
    {
        if (value)
        {
            SetLayersOnColliders(playerHitBoxLayer, playerHurtBoxLayer);
            gameObject.AddComponent<PlayerController>();
        }
        else
        {
            SetLayersOnColliders(enemyHitBoxLayer, enemyHurtBoxLayer);

            PlayerController PlayerController = gameObject.GetComponent<PlayerController>();
            if (PlayerController != null)
                Destroy(PlayerController);
        }
    }

    public int GetHitLayerMask()
    {
        if (isPlayer)
            return playerHitBoxLayer;
        else
            return enemyHitBoxLayer;
    }

    protected void SetLayersOnColliders(LayerMask hitBoxLayerMask, LayerMask hurtBoxLayerMask)
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

    public void TakeDamage(string takeHitReaction, float damage)
    {
        int takeHitReactionHash = Animator.StringToHash(takeHitReaction);
        Animator.SetTrigger(takeHitReactionHash);

        health.ReduceHealth(damage);
    }


}
