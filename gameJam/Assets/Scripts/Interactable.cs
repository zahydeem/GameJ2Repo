using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    private float range = 1f;

    public bool playerWithinRange()
    {
        return Vector2.Distance(GameController.gameController.player.transform.position, transform.position) < range;
    }

    protected abstract void Action();

}
