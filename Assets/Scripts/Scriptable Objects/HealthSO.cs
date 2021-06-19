using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HealthSO : ScriptableObject
{
    public HealthBar HealthBar;

    public float maxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
            HealthBar.maxHealth = _maxHealth;
        }
    }

    private float _maxHealth;

    public float currentHealth
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;
            HealthBar.currentHealth = _currentHealth;
        }
    }

    private float _currentHealth;
}
