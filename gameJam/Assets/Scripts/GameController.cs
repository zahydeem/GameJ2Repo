using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController gameController;

    public GameObject player;
    public GameObject note;

    public int toolBarSize;

    public GameObject[] currentBar;

    public static GameObject toolBar;


    // Start is called before the first frame update
    void Awake()
    {
        gameController = this;
        player = transform.GetChild(0).gameObject;

        currentBar = new GameObject[toolBarSize];
    }

    private void Update()
    {
        
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Collider2D[] allClicked = SelectObjects();
            for (int i = 0; i < allClicked.Length; i++)
            {
                Debug.Log(allClicked[i].name);
                if (player.GetComponent<PlayerMovement>().isWithinRange(allClicked[i].gameObject))
                {
                    if (allClicked[i].gameObject.GetComponent<ToolInfo>() != null)
                    {
                        Debug.Log("Working");
                        PickUpTool(allClicked[i].gameObject);
                        player.GetComponent<PlayerMovement>().ReachFor();
                        return;
                    }
                    else if (allClicked[i].tag == "Note")
                    {
            
                        allClicked[i].GetComponent<NoteSelect>().Mess();
                        return;
                    }
                }
            }
            player.GetComponent<PlayerMovement>().Attack();
        }
    }

    private Collider2D[] SelectObjects()
    {
        return Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    public void PickUpTool(GameObject tool)
    {
        toolBar.GetComponent<ToolBar>().PickUpTool(tool);
    }

    public void UseTool(GameObject cellImage)
    {
        Debug.Log("UsingTool");
        GameObject tool = toolBar.GetComponent<ToolBar>().RemoveToolFromBar(cellImage);
        Debug.Log("Found a tool: " + tool.name);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            tool.GetComponent<ToolInfo>().DropTool();
        }
        else
        {
            tool.GetComponent<ToolInfo>().UseTool();
        }
    }
}
