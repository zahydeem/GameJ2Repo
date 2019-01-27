using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NoteSelect : MonoBehaviour
{
    public Text text;
    public Image popup;
    GameObject note;
    public string story;

    // Start is called before the first frame update
    void Awake()
    {
       popup.enabled = false;
       text.enabled = false;
      
    }
    public void Mess()
    {
        popup.enabled = true;
        text.enabled = true;
        text.text = story;
        
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



