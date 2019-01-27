using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController gameController;

    public GameObject player;
    public GameObject note;

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
            GameObject clicked = SelectObject();
            Debug.Log(clicked.name);
            if (clicked != null && player.GetComponent<PlayerMovement>().isWithinRange(clicked))
            {
                if (SelectObject().tag == "Interactable")
                {
                    player.GetComponent<PlayerMovement>().ReachFor();

                }
                else if (SelectObject().tag == "Note")
                {
                    note.GetComponent<NoteSelect>().Mess();
                }
                else
                {
                    player.GetComponent<PlayerMovement>().Attack();
                }
            }
        }
    }
  
    private GameObject SelectObject()
    {
        return Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero).collider.gameObject;
    }
}
