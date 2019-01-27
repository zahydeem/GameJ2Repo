using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCritter : EnemyMovement
{
    float waitTime = 2000f;
    float attackSpeed = 8f;

    float attackTime = 1000f;

    IEnumerator thisCoroutine;

    /*
    override protected void Attack()
    {
        thisCoroutine = WaitRoutine();
        StartCoroutine(thisCoroutine);

        loopStartedTime = Time.time;
        Collider2D thisCollider = GetComponent<Collider2D>();
        Collider2D playerCollider = player.GetComponent<Collider2D>();
        while (Time.time - loopStartedTime < attackTime)
        {
            Move(attackSpeed);
            if (thisCollider.IsTouching(playerCollider))
            {
                GetComponent<GenericCreature>().DealDamage(player);
                break;
            }
        }

    }



    IEnumerator WaitRoutine()
    {
        while (isInside)
        {
            GManager.numBones--;
            yield return new WaitForSeconds(1);
        }
        if (!isInside)
        {
            StopCoroutine(thisCoroutine);
            yield return null;
        }
    }
    */
}
