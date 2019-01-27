using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolInfo : MonoBehaviour
{
    public int extraDamage = 0;
    public bool consumable = false;
    public int healthRestore = 0;

    public int GetDamage()
    {
        return extraDamage;
    }

    public void Consume()
    {
        if (consumable)
        {
            GameController.gameController.player.GetComponent<GenericCreature>().AddHealth(healthRestore);
        }
        Destroy(this.gameObject);
    }
}
