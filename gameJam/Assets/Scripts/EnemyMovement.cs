using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : AbstractMovement
{
    GameObject player;

    SpriteRenderer spriteRenderer;

    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameController.gameController.player;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (spriteRenderer.isVisible)
        {
            Vector2 copyOfPosition = transform.position;
            Vector2 xAndYMovmentDegrees = vertAndHorRatio();
            transform.position = new Vector2(
                transform.position.x + xAndYMovmentDegrees.x * Time.deltaTime * moveSpeed,
                transform.position.y + xAndYMovmentDegrees.y * Time.deltaTime * moveSpeed
            );
            if (!CanMove())
            {
                transform.position = copyOfPosition;
            }
        }
        FlipHor();
    }

    private Vector2 vertAndHorRatio()
    {
        float xDis = player.transform.position.x - transform.position.x;
        float yDis = player.GetComponent<SpriteRenderer>().bounds.min.y - transform.position.y;
        float totalDis = Mathf.Abs(xDis) + Mathf.Abs(yDis);
        Vector2 retVec = new Vector2(
            xDis / totalDis,
            yDis / totalDis
        );
        return retVec;
    }
}
