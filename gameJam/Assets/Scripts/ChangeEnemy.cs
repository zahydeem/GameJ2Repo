using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEnemy : MonoBehaviour
{
    
    public Sprite D1, D2, D3;
    int tick = 0;
    public float speed;
    bool isChanging = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isChanging == false) {
            isChanging = true;
            StartCoroutine(Next());

            if (tick == 0)
            {
                this.GetComponent<SpriteRenderer>().sprite = D1;
            }
            else if (tick == 1)
            {
                this.GetComponent<SpriteRenderer>().sprite = D2;
            }
            else if (tick == 2)
            {
                this.GetComponent<SpriteRenderer>().sprite = D3;
      
            }
            else if (tick == 3)
            {
                this.GetComponent<SpriteRenderer>().sprite = D2;
                tick = -1;
            }
        }

    }

    IEnumerator Next()
    {
        tick++;
        yield return new WaitForSeconds(speed);
        isChanging = false;
        
    }
    
}