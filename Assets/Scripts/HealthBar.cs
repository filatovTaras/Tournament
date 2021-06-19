using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private HealthSO PlayerHealthSO;
    [SerializeField]
    private HealthSO EnemyHealthSO;
    private HealthSO HealthSO;

    [SerializeField]
    private Slider Slider;

    [SerializeField]
    private bool isPlayer;

    public float currentHealth
    {
        get
        {
            return Slider.value;
        }
        set
        {
            if (value > Slider.maxValue)
                value = Slider.maxValue;

            if (value < 0)
                value = 0;

            Slider.value = value;
        }
    }

    public float maxHealth
    {
        get
        {
            return Slider.maxValue;
        }
        set
        {
            if (value < Slider.minValue)
                value = Slider.minValue;

            Slider.maxValue = value;
        }
    }

    void Awake()
    {
        RegisterInSO();
    }
    
    private void RegisterInSO()
    {
        if (isPlayer)
            HealthSO = PlayerHealthSO;
        else
            HealthSO = EnemyHealthSO;

        HealthSO.HealthBar = this;
    }
    
}
