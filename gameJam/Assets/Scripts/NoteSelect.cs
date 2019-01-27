using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NoteSelect : MonoBehaviour
{
    public Text text;
    public Image popup;
    GameObject note;

    // Start is called before the first frame update
    void Awake()
    {
       popup.enabled = false;
       text.enabled = false;
        print("nope");
    }
    public void Mess()
    {
        popup.enabled = true;
        text.enabled = true;

        if (note.name == "Note1")
        {
            text.text = "MOVE TO THE NEXT ISLAND";
        }
        else if (note.name == "Note2")
        {
            text.text = "Just Give up";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && popup.enabled == true)
        {
            print("die");
            popup.enabled = false;
            text.enabled = false;
        }
        
        

    }
}



