using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private List<SphereCollider> hitBoxes = new List<SphereCollider>();
    [SerializeField]
    private List<CapsuleCollider> hurtBoxes = new List<CapsuleCollider>();

    private readonly LayerMask playerHitBoxLayer = 10;
    private readonly LayerMask playerHurtBoxLayer = 11;
    private readonly LayerMask enemyHitBoxLayer = 12;
    private readonly LayerMask enemyHurtBoxLayer = 13;

    [SerializeField]
    private bool isPlayer = false; // Для тестов

    void Start()
    {
        SetIsPlayer(isPlayer); // Для тестов
    }

    public void SetIsPlayer(bool isPlayer)
    {
        if (isPlayer)
        {
            SetLayersOnColliders(playerHitBoxLayer, playerHurtBoxLayer);
            gameObject.AddComponent<PlayerController>();
        }
        else
        {
            SetLayersOnColliders(enemyHitBoxLayer, enemyHurtBoxLayer);
        }
    }

    private void SetLayersOnColliders(LayerMask hitBoxLayerMask, LayerMask hurtBoxLayerMask)
    {
        foreach(SphereCollider hitBox in hitBoxes)
        {
            hitBox.gameObject.layer = hitBoxLayerMask;
        }

        foreach(CapsuleCollider hurtBox in hurtBoxes)
        {
            hurtBox.gameObject.layer = hurtBoxLayerMask;
        }
    }
}
