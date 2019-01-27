using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericCreature : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public int naturalDamage;
    
    private Animator anim;
    private Animator Planim;

    // Start is called before the first frame update
    void Start()
    {
        RefreshHealth();
        if (gameObject.tag == "Enemy")
        {
            anim = GetComponent<Animator>();
        }
        if (gameObject.tag == "Player")
        {
            Planim = GetComponent<Animator>();
        }
    }

    public void RefreshHealth()
    {
        currentHealth = maxHealth;
    }

    public void AddHealth(int healthGained)
    {
        currentHealth += healthGained;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
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
        GetComponent<AbstractMovement>().PushOther(objectTakingDamage, 0.15f);
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

        if (gameObject.tag == "Enemy")
        {
            anim.SetInteger("Plau", 0);
        }
        if (gameObject.tag == "Player")
        {
            Planim.SetInteger("ourdie", 0);
        }
        StartCoroutine(WaitForDeath());

        
    }

    IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(1.2f);
        Destroy(this.gameObject);
    }
}
