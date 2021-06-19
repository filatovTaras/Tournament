using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private HealthSO PlayerHealthSO;
    [SerializeField]
    private HealthSO EnemyHealthSO;
    private HealthSO HealthSO;

    [SerializeField]
    private Character Character;

    [SerializeField]
    private float _maxHealth;
    [SerializeField]
    private float _currentHealth;

    private bool isPlayer;

    private float maxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
            HealthSO.maxHealth = _maxHealth;
        }
    }

    private float currentHealth
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;
            HealthSO.currentHealth = _currentHealth;
        }
    }

    void Start()
    {
        if (Character == null)
            Character = GetComponent<Character>();

        if (Character == null)
            Debug.LogError("Компоненту Health для работы необходим компонент Character в объекте " + gameObject.name);

        isPlayer = Character.isPlayer;
        SelectSO();
        maxHealth = _maxHealth;
        currentHealth = maxHealth;
    }

    public void ReduceHealth(float value)
    {
        currentHealth -= value;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if(currentHealth < 0)
        {
            Debug.Log("Смерть");
        }
    }

    private void SelectSO()
    {
        if (isPlayer)
            HealthSO = PlayerHealthSO;
        else
            HealthSO = EnemyHealthSO;
    }
}
