using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractCreature : MonoBehaviour
{
    public float maxHealth;

    public float currentHealth;

    private void Start()
    {
        RefreshHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RefreshHealth()
    {
        currentHealth = maxHealth;
    }
}
