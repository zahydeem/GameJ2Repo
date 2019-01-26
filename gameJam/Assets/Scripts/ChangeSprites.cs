﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprites : MonoBehaviour
{
    public Sprite frontGhost, backGhost, idleGhost, sideMoveGhost;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.GetComponent<SpriteRenderer>().sprite = backGhost;
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.GetComponent<SpriteRenderer>().sprite = sideMoveGhost;
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.GetComponent<SpriteRenderer>().sprite = frontGhost;
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.GetComponent<SpriteRenderer>().sprite = sideMoveGhost;
        }
    }
}
