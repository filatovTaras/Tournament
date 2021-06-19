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
        CharacterHitted = other.GetComponent<HurtBox>().Character;
        enterCount++;
    }

    private void OnTriggerExit(Collider other)
    {
        enterCount--;

        if (enterCount > 0) return;

        ResetCharacterHitted();
    }

    private Character ResetCharacterHitted()
    {
        Character chrc = CharacterHitted;
        CharacterHitted = null;
        enterCount = 0;

        return chrc;
    }

    public Character GetCharacterHitted(bool isResetData)
    {
        return (isResetData) ? ResetCharacterHitted() : CharacterHitted;
    }
}
