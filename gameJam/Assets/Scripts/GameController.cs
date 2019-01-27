﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController gameController;

    public GameObject player;

    public float toolBarSize;

    // Start is called before the first frame update
    void Awake()
    {
        gameController = this;
        player = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (SelectObject().tag == "Interactable")
            {
            }
            else 
            {
                player.GetComponent<PlayerMovement>().Attack();
            }
        }
    }
    
    private GameObject SelectObject()
    {
        return Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero).collider.gameObject;
    }
}
