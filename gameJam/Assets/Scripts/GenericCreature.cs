using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericCreature : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public int naturalDamage;

    // Start is called before the first frame update
    void Start()
    {
        RefreshHealth();
    }

    public void RefreshHealth()
    {
        currentHealth = maxHealth;
    }

    public void DealDamage(GameObject objectTakingDamage)
    {
        int damage = naturalDamage;
        for (int childIndex = 0; childIndex < transform.childCount; childIndex++)
        {
            if (transform.GetChild(childIndex).tag == "Tool")
            {
                damage += transform.GetChild(childIndex).GetComponent<ToolInfo>().GetDamage();
            }
        }
        objectTakingDamage.GetComponent<GenericCreature>().TakeDamage(damage);
    }

    public void TakeDamage(int amountOfDamage)
    {
        currentHealth -= amountOfDamage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    //TODO
    private void Die()
    {

    }
}
