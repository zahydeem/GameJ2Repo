using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCritter : EnemyMovement
{
    float waitTime = 2f;
    float attackSpeed = 8f;

    float attackTime = 1000f;
    float waitTimeStart;

    IEnumerator thisCoroutine;

    override protected void Attack()
    {
        thisCoroutine = WaitRoutine();
        StartCoroutine(thisCoroutine);

        waitTimeStart = Time.time;
        thisCoroutine = AttackRoutine();
        StartCoroutine(thisCoroutine);
    }



    IEnumerator WaitRoutine()
    {
        yield break new WaitForSeconds(waitTime);
        StopCoroutine(thisCoroutine);
        yield return null;
    }
    IEnumerator AttackRoutine()
    {
        Collider2D thisCollider = GetComponent<Collider2D>();
        while (Time.timeScale - waitTimeStart < attackTime)
        {
            Collider2D playerCollider = player.GetComponent<Collider2D>();
            Move(attackSpeed);
            if (thisCollider.IsTouching(playerCollider))
            {
                GetComponent<GenericCreature>().DealDamage(player);
            }
            yield return null;
        }
        StopCoroutine(thisCoroutine);
        yield return null;
    }

}
