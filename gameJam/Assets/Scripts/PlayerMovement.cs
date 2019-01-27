using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : AbstractMovement
{
    float moveSpeed = 4f;
    Vector3 forward, right;
    ContactFilter2D contactFilter;
    float swingSize = 1f;

    enum Dir
    {
        right,
        left,
        down,
        up
    };

    Dir dir;

    // Start is called before the first frame update
    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        dir = Dir.right;

        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(LayerMask.NameToLayer("Ground"));
        contactFilter.useLayerMask = true;
        
    }

    private void FixedUpdate()
    {
        Vector3 copyOfPosition = transform.position;
        float adjustedMoveSpeed = moveSpeed;
        if (Input.GetAxis("HorizontalKey") != 0 && Input.GetAxis("VerticalKey") != 0)
        {
            adjustedMoveSpeed /= 1.41f;
        }
        transform.position += new Vector3(
            adjustedMoveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey"),
            adjustedMoveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey"),
            0f
        );
        if (!CanMove())
        {
            transform.position = copyOfPosition;
        }
        Flip();
        FlipHor();
    }

    private void Flip()
    {
        if (Input.GetAxis("VerticalKey") == 1 && dir != Dir.up)
        {
            dir = Dir.up;
        }
        else if (Input.GetAxis("HorizontalKey") == -1 && dir != Dir.left)
        {
            dir = Dir.left;
        }
        else if (Input.GetAxis("HorizontalKey") == 1 && dir != Dir.right)
        {
            dir = Dir.right;
        }
        else if (Input.GetAxis("VerticalKey") == -1 && dir != Dir.down)
        {
            dir = Dir.down;
        }
    }

    /*
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            Move();
        }
    }

    private void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

        Vector3 headingDir = Vector3.Normalize(rightMovement + upMovement);
        //transform.forward = headingDir;
        transform.position += rightMovement;
        transform.position += upMovement;
    }
    **/
    public void Attack()
    {
        Vector2 centerPoint = DetermineSwingArea();

        Collider2D[] collidersAttack = Physics2D.OverlapBoxAll(centerPoint, new Vector2(swingSize/2, swingSize/2), 0f);
        foreach (Collider2D collider in collidersAttack)
        {
            if (collider.tag == "Enemy")
            {
                GetComponent<GenericCreature>().DealDamage(collider.gameObject);
            }
        }
    }

    private Vector2 DetermineSwingArea()
    {
        Vector2 point = new Vector2();
        float halfSwingSize = swingSize / 2;
        if (dir == Dir.up)
        {
            point = new Vector2(
                0f,
                halfSwingSize
            );
        }
        else if(dir == Dir.left)
        {
            point = new Vector2(
                -halfSwingSize,
                0f
            );
        }
        else if (dir == Dir.right)
        {
            point = new Vector2(
                halfSwingSize,
                0f
            );
        }
        else if (dir == Dir.down)
        {
            point = new Vector2(
                0f,
                -halfSwingSize
            );
        }
        point = new Vector2(
            transform.position.x + point.x,
            transform.position.y + point.y
        );
        return point;
    }
}
