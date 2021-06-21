using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpecial : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem firePrefab;

    [SerializeField]
    private Transform startPosition;

    [SerializeField]
    private int damage = 0;

    [SerializeField]
    private string hitReaction;

    private ParticleSystem fire;

    private Character character;

    private HitDetector fireHitDetector;

    void Start()
    {
        character = GetComponent<Character>();
        int layerMask = character.GetHitLayerMask();

        fire = Instantiate(firePrefab);
        fire.gameObject.layer = layerMask;
        fire.Stop();

        fireHitDetector = fire.GetComponent<HitDetector>();
    }

    private void LaunchSP1()
    {
        fire.transform.position = startPosition.position;

        fire.Play();

        fireHitDetector.ActivateDetector(hitReaction, damage);
    }
}
