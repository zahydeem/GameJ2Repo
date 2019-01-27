using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEnemy : MonoBehaviour
{
    
    public Sprite D1, D2, D3;
    int tick = 0;
    public float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(Next());
        if (tick == 0)
        {
            this.GetComponent<SpriteRenderer>().sprite = D1;
        }
        if (tick == 1)
        {
            this.GetComponent<SpriteRenderer>().sprite = D2;
        }
        if (tick == 2)
        {
            this.GetComponent<SpriteRenderer>().sprite = D3;
            tick = 0;
        }

    }

    IEnumerator Next()
    {
        tick++;
        yield return new WaitForSecondsRealtime(speed);
        
    }
    
}