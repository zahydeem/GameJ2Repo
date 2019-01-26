using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractCreature : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        RefreshHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void private RefreshHealth()
    {
        currentHealth = maxHealth();
    }
}
