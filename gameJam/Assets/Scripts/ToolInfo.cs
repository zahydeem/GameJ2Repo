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
        GenericCreature genericPlayer = GameController.gameController.player.GetComponent<GenericCreature>();
        if (consumable && (genericPlayer.currentHealth < genericPlayer.maxHealth ||
        genericPlayer.currentHealth + healthRestore < genericPlayer.maxHealth))
        {
            Consume();
        }
        else
        {
            GameController.gameController.PickUpTool(this.gameObject);
        }
    }

    public int GetDamage()
    {
        return extraDamage;
    }

    public void Consume()
    { 
        GameController.gameController.player.GetComponent<GenericCreature>().AddHealth(healthRestore);
        Destroy(this.gameObject);
    }
    public void DropTool()
    {
        transform.position = GameController.gameController.player.transform.position;
        gameObject.SetActive(true);
    }
    public void UseTool()
    {
        Action();
    }

}
