using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : AbstractMovement
{
    float moveSpeed = 4f;
    Vector3 forward, right;
    ContactFilter2D contactFilter;

    enum Dir
    {
        right,
        left,
        up,
        down,
        upRight,
        downRight,
        upLeft,
        downLeft,
        none
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

    private void Update()
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
        if (Input.GetAxis("HorizontalKey") != 0 && Input.GetAxis("VerticalKey") != 0)
        {
            if (Input.GetAxis("HorizontalKey") == 1 && Input.GetAxis("VerticalKey") == 1 && dir != Dir.upRight)
            {
                dir = Dir.upRight;
            }
            else if (Input.GetAxis("HorizontalKey") == 1 && Input.GetAxis("VerticalKey") == -1 && dir != Dir.downRight)
            {
                dir = Dir.downRight;
            }
            else if (Input.GetAxis("HorizontalKey") == -1 && Input.GetAxis("VerticalKey") == 1 && dir != Dir.upLeft)
            {
                dir = Dir.upLeft;
            }
            else if (Input.GetAxis("HorizontalKey") == -1 && Input.GetAxis("VerticalKey") == -1 && dir != Dir.downLeft)
            {
                dir = Dir.downLeft;
            }
        }
        else
        {
            if (Input.GetAxis("HorizontalKey") == 1 && dir != Dir.right)
            {
                dir = Dir.right;
            }
            else if (Input.GetAxis("HorizontalKey") == -1 && dir != Dir.left)
            {
                dir = Dir.left;
            }
            else if (Input.GetAxis("VerticalKey") == 1 && dir != Dir.up)
            {
                dir = Dir.up;
            }
            else if (Input.GetAxis("VerticalKey") == -1 && dir != Dir.down)
            {
                dir = Dir.down;
            }
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

}
