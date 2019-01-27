using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeArmAnimation : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetInteger("Movement", 4);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            anim.SetInteger("Movement", 1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            anim.SetInteger("Movement", 2);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetInteger("Movement", 3);
        }
        else
        {
            anim.SetInteger("Movement", 0);
        }
    }
}
