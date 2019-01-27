using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolInfo : Interactable
{
    public int extraDamage = 0;
    public bool consumable = false;
    public int healthRestore = 0;

    protected override void Action()
    {
        GameController.gameController.PickUpTool(gameObject);
    }

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
