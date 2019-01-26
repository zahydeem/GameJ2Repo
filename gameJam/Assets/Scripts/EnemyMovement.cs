using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : AbstractMovement
{
    GameObject player;

    SpriteRenderer spriteRenderer;
    SpriteRenderer playerSR;

    public float moveSpeed;
    public float closeDistance = 1f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameController.gameController.player;
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerSR = player.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (spriteRenderer.isVisible && !IsCloseEnough())
        {
            Vector2 copyOfPosition = transform.position;
            Vector2 xAndYMovmentDegrees = VertAndHorRatio();
            transform.position = new Vector2(
                transform.position.x + xAndYMovmentDegrees.x * Time.deltaTime * moveSpeed,
                transform.position.y + xAndYMovmentDegrees.y * Time.deltaTime * moveSpeed
            );
            if (!CanMove())
            {
                transform.position = copyOfPosition;
            }
            FlipHor();
        }
    }

    private bool IsCloseEnough()
    {
        Debug.Log((player.transform.position.y - transform.position.y) + " " + (playerSR.bounds.min.x - transform.position.x));
        bool ret = Mathf.Abs(player.transform.position.x - transform.position.x) < closeDistance &&
                    Mathf.Abs(playerSR.bounds.min.y - transform.position.y) < closeDistance;
        return ret;
    }

    private Vector2 VertAndHorRatio()
    {
        float xDis = player.transform.position.x - transform.position.x;
        float yDis = playerSR.bounds.min.y - transform.position.y;
        float totalDis = Mathf.Abs(xDis) + Mathf.Abs(yDis);
        Vector2 retVec = new Vector2(
            xDis / totalDis,
            yDis / totalDis
        );
        return retVec;
    }
}
