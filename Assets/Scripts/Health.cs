using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float currentHealth;

    void Start()
    {
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
}
