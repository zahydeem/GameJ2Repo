using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBar : MonoBehaviour
{
    private float numCells;

    // Start is called before the first frame update
    void Start()
    {
        numCells = GameController.gameController.toolBarSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
