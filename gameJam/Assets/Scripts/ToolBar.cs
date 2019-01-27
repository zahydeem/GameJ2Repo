using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBar : MonoBehaviour
{
    public GameObject cellPrefab;
    private float numCells;
    private GameObject[] cellArray;

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
        GameObject[] cellArray = new GameObject[Mathf.FloorToInt(numCells)];
        for (int i = 0; i < numCells; i++)
        {
            cellArray[i] = CreateCell();
        
        }
    }

    private GameObject CreateCell()
    {
        GameObject cell;
        cell = Instantiate(cellPrefab, transform);
        return cell;
    }
}
