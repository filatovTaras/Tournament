using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetector : MonoBehaviour
{
    [SerializeField]
    private SphereCollider hitCollider;

    private string hitReaction = "";

    private float damage = 0;

    void Start()
    {
        hitCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Character target = other.GetComponent<HurtBox>().Character;

        if (target == null)
            return;

        target.TakeDamage(hitReaction, damage);

        DeactivateDetector();
    }

    public void ActivateDetector(string hitReaction, float damage)
    {
        this.hitReaction = hitReaction;
        this.damage = damage;

        hitCollider.enabled = true;
    }

    public void DeactivateDetector()
    {
        hitReaction = "";
        damage = 0;

        hitCollider.enabled = false;
    }
}
