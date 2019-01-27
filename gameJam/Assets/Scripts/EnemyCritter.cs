using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCritter : EnemyMovement
{
    float waitTime = 1f;
    float attackSpeed = 5f;

    float attackTime = 1;
    float waitTimeStart;
    

    IEnumerator thisCoroutine;

   

    override protected void Attack()
    {
        thisCoroutine = AttackRoutine();
        StartCoroutine(thisCoroutine);
    }

    private void Lung(float givenMoveSpeed, Vector2 xAndYMovementDegrees)
    {
        Vector2 copyOfPosition = transform.position;
        transform.position = new Vector2(
            transform.position.x + xAndYMovementDegrees.x * Time.deltaTime * attackSpeed,
            transform.position.y + xAndYMovementDegrees.y * Time.deltaTime * attackSpeed
        );
        if (!CanMove())
        {
            transform.position = copyOfPosition;
        }
    }

    IEnumerator AttackRoutine()
    {
        
        yield return new WaitForSeconds(waitTime);
        if (anit.GetInteger("Plau") == 0)
        {
            StopCoroutine(thisCoroutine);
            yield return null;
        }
        Collider2D thisCollider = GetComponent<Collider2D>();
        Collider2D playerCollider = player.GetComponent<Collider2D>();
        Vector2 xAndYMovementDegrees = VertAndHorRatio();
        waitTimeStart = Time.time;
        bool hit = false;
        while (Time.time - waitTimeStart < attackTime && !hit)
        {
            if (anit.GetInteger("Plau") == 0)
            {
                StopCoroutine(thisCoroutine);
                yield return null;
            }
            Lung(attackSpeed, xAndYMovementDegrees);

            if (GetComponent<Collider2D>().OverlapPoint(player.transform.position))
            {
                GetComponent<GenericCreature>().DealDamage(player);
                hit = true;
            }
            yield return null;
        }
        waitTimeStart = Time.time;
        while (Time.time - waitTimeStart < 0.05f)
        {
            if (anit.GetInteger("Plau") == 0)
            {
                StopCoroutine(thisCoroutine);
                yield return null;
            }
            Rebound(attackSpeed, xAndYMovementDegrees);
            yield return null;

        }
        isAttacking = false;
        StopCoroutine(thisCoroutine);
        yield return null;
    }

    void Rebound(float givenMoveSpeed, Vector2 xAndYMovementDegrees)
    {
        Vector2 copyOfPosition = transform.position;
        transform.position = new Vector2(
            transform.position.x - xAndYMovementDegrees.x * Time.deltaTime * attackSpeed,
            transform.position.y - xAndYMovementDegrees.y * Time.deltaTime * attackSpeed
        );
        if (!CanMove())
        {
            transform.position = copyOfPosition;
        }
    }

}
