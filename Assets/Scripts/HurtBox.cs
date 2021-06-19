using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    public Character Character
    {
        get { return _Character; }
        private set { return; }
    }

    [SerializeField]
    private Character _Character;
}
