using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class attack : MonoBehaviour
{
    private Vector2 target;
    public float speed = 1.0f;

    void OnStart()
    {
        
    }

    void Update()
    {
       
        //Shoot();
        
    }

  /*  void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float step = speed * Time.deltaTime;
            while(transform.position.x != target.x && transform.position.y != target.y)
            {
                transform.position = Vector2.MoveTowards(transform.position, target, 0.00001f).normalized;
            }
            
        }
    }*/
}

