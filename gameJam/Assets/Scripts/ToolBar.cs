using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBar : MonoBehaviour
{
    public GameObject cellPrefab;

    private float numCells;

    // Start is called before the first frame update
    void Start()
    {
        numCells = GameController.gameController.toolBarSize;
        Populate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Populate()
    {
        for (int i = 0; i < numCells; i++)
        {
            CreateCell();
        }
    }

    private void CreateCell()
    {
        GameObject cell;
        cell = Instantiate(cellPrefab, transform);
    }
}
