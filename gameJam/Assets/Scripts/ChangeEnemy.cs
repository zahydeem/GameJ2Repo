using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEnemy : MonoBehaviour
{
    public Sprite D1, D2, D3;
    int tick = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Next);
        tick++;

        if(tick%1 ==0)
        this.GetComponent<SpriteRenderer>().sprite = D1;
        this.GetComponent<SpriteRenderer>().sprite = D1;
        this.GetComponent<SpriteRenderer>().sprite = D1;

    }

    IEnumerator Next()
    {
        yield re
    }
}
