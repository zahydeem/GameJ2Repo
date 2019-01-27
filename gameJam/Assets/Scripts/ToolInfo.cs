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
        if (consumable)
        {
            Consume();
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
