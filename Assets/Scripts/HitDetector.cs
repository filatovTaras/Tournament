using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetector : MonoBehaviour
{
    [SerializeField]
    private Character CharacterHitted = null;

    private int enterCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        CharacterHitted = other.GetComponent<HurtBox>().GetCharacterComponent();
        enterCount++;
    }

    private void OnTriggerExit(Collider other)
    {
        enterCount--;

        if (enterCount > 0) return;

        ResetCharacterHitted();
    }

    public void ResetCharacterHitted()
    {
        CharacterHitted = null;
        enterCount = 0;
    }

    public Character GetCharacterHitted()
    {
        return CharacterHitted;
    }
}
