using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractMovement : MonoBehaviour
{
    Vector2 lastPosition;
    SpriteRenderer spriteRenderer;

    enum HorDir { left, right };
    HorDir horDir;

    float epsilon = 0.01f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        horDir = HorDir.left;
    }

    protected bool CanMove()
    {
        Vector2 point = new Vector2(
            spriteRenderer.bounds.min.x,
            spriteRenderer.bounds.min.y
        );
        Collider2D[] bottomLeftColliders = Physics2D.OverlapPointAll(point);
        point = new Vector2(
            spriteRenderer.bounds.max.x,
            spriteRenderer.bounds.min.y
        );
        Collider2D[] bottomRightColliders = Physics2D.OverlapPointAll(point);

        int enoughGroundCount = 0;
        foreach (Collider2D collider in bottomLeftColliders)
        {
            if (collider != null && collider.name.Equals("GroundMap"))
            {
                enoughGroundCount++;
            }
        }
        foreach (Collider2D collider in bottomRightColliders)
        {
            if (collider != null && collider.name.Equals("GroundMap"))
            {
                enoughGroundCount++;
            }
        }
        return enoughGroundCount >= 2;
    }

    protected void FlipHor()
    {
        if ((transform.position.x - lastPosition.x) > epsilon && horDir != HorDir.right)
        {
            transform.localScale = new Vector3(
                transform.localScale.x * -1,
                transform.localScale.y,
                transform.localScale.z
            );
            horDir = HorDir.right;
        }
        else if ((lastPosition.x - transform.position.x) > epsilon && horDir != HorDir.left)
        {
            transform.localScale = new Vector3(
                transform.localScale.x * -1,
                transform.localScale.y,
                transform.localScale.z
            );
            horDir = HorDir.left;
        }
        lastPosition = transform.position;
    }
}
