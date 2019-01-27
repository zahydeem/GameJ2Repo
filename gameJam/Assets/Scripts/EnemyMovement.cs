using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMovement : AbstractMovement
{
    protected GameObject player;

    protected SpriteRenderer spriteRenderer;
    protected SpriteRenderer playerSR;

    public float moveSpeed;
    public float closeDistance = 1f;

    protected bool isAttacking;
    protected Animator anit;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameController.gameController.player;
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerSR = player.GetComponent<SpriteRenderer>();
        isAttacking = false;
        
        anit = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isAttacking)
        {
            if (IsCloseEnough())
            {
                isAttacking = true;
                Attack();
            }
            else
            {
                Move(moveSpeed);
            }
        }
    }

    protected void Move(float givenMoveSpeed)
    {
        if (spriteRenderer.isVisible)
        {
            Vector2 copyOfPosition = transform.position;
            Vector2 xAndYMovementDegrees = VertAndHorRatio();
            transform.position = new Vector2(
                transform.position.x + xAndYMovementDegrees.x * Time.deltaTime * givenMoveSpeed,
                transform.position.y + xAndYMovementDegrees.y * Time.deltaTime * givenMoveSpeed
            );
            if (!CanMove())
            {
                transform.position = copyOfPosition;
            }
            FlipHor();
        }
    }


    protected bool IsCloseEnough()
    {
        bool ret = Mathf.Abs(player.transform.position.x - transform.position.x) < closeDistance &&
                    Mathf.Abs(player.transform.position.y - transform.position.y) < closeDistance;
        return ret;
    }
       

    protected Vector2 VertAndHorRatio()
    {
        float xDis = player.transform.position.x - transform.position.x;
        float yDis = player.transform.position.y - transform.position.y;
        float totalDis = Mathf.Abs(xDis) + Mathf.Abs(yDis);
        Vector2 retVec = new Vector2(
            xDis / totalDis,
            yDis / totalDis
        );
        return retVec;
    }

    protected abstract void Attack();
}
