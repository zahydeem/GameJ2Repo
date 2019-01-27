using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController gameController;

    public GameObject player;

    public float toolBarSize;
    public Text text;
    public Image popup;

    // Start is called before the first frame update
    void Awake()
    {
        gameController = this;
        player = transform.GetChild(0).gameObject;

        popup.enabled = false;
        text.enabled = false;
      
     
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && popup.enabled == true)
        {
            print("die");
            popup.enabled = false;
            text.enabled = false;
        }
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
                    popup.enabled = true;
                    text.enabled = true;
                    if (SelectObject().name == "Note1")
                    {
                        text.text = "MOVE TO THE NEXT ISLAND";
                    }
                   else if (SelectObject().name == "Note2")
                    {
                        text.text = "Just Give up";
                    }

                }
               
                else
                {
                    player.GetComponent<PlayerMovement>().Attack();
                }
            }
        }
    }
    private void OnMouseDown(Collider2D other)
    {
        if(other.tag == "Note")
        {
            print("check");
        }
    }
    private GameObject SelectObject()
    {
        return Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero).collider.gameObject;
    }
}
