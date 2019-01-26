using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float moveSpeed = 4f;
    Vector3 forward, right;

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
        
    }

    private void Update()
    {
        transform.position += new Vector3(
            moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey"),
            moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey"),
            0f
            );
        Flip();
    }

    private void Flip()
    {
        if (Input.GetAxis("HorizontalKey") != 0 && Input.GetAxis("VerticalKey") != 0)
        {
            if (Input.GetAxis("HorizontalKey") == 1 && Input.GetAxis("VerticalKey") == 1 && dir != Dir.upRight)
            {
                FlipHor(Dir.right);
                dir = Dir.upRight;
            }
            else if (Input.GetAxis("HorizontalKey") == 1 && Input.GetAxis("VerticalKey") == -1 && dir != Dir.downRight)
            {
                FlipHor(Dir.right);
                dir = Dir.downRight;
            }
            else if (Input.GetAxis("HorizontalKey") == -1 && Input.GetAxis("VerticalKey") == 1 && dir != Dir.upLeft)
            {
                FlipHor(Dir.left);
                dir = Dir.upLeft;
            }
            else if (Input.GetAxis("HorizontalKey") == -1 && Input.GetAxis("VerticalKey") == -1 && dir != Dir.downLeft)
            {
                FlipHor(Dir.left);
                dir = Dir.downLeft;
            }
        }
        else
        {
            if (Input.GetAxis("HorizontalKey") == 1 && dir != Dir.right)
            {
                FlipHor(Dir.right);
                dir = Dir.right;
            }
            else if (Input.GetAxis("HorizontalKey") == -1 && dir != Dir.left)
            {
                FlipHor(Dir.left);
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

    private void FlipHor(Dir givenDir)
    {
        if (transform.localScale.x > 0 && givenDir == Dir.left)
        {
            transform.localScale = new Vector3(
                transform.localScale.x * -1,
                transform.localScale.y,
                transform.localScale.z
            );
        }
        else if (transform.localScale.x < 0 && givenDir == Dir.right)
        {
            transform.localScale = new Vector3(
                transform.localScale.x * -1,
                transform.localScale.y,
                transform.localScale.z
            );
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
