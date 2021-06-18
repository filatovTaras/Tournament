using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    [SerializeField]
    private Character Character;

    public Character GetCharacterComponent()
    {
        return Character;
    }
}
