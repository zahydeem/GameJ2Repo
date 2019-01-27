using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        GameController.toolBar = this.gameObject;
    }

    public void PickUpTool(GameObject tool)
    {
        int slotNum = FindAvailableToolSlot();
        if (slotNum != -1)
        {
            tool.transform.SetParent(cellArray[slotNum].transform);
            tool.SetActive(false);
            Image toolImage = cellArray[slotNum].transform.GetChild(0).GetComponent<Image>();
            toolImage.sprite = tool.GetComponent<SpriteRenderer>().sprite;
            toolImage.enabled = true;
        }
    }
    public GameObject RemoveToolFromBar(GameObject givenCellImage)
    {
        int slotNum = FindToolCellSlot(givenCellImage);
        GameObject cell = cellArray[slotNum];
        cell.transform.GetChild(0).GetComponent<Image>().enabled = false;
        GameObject tool = cell.transform.GetChild(1).gameObject;
        tool.transform.SetParent(null);
        return tool;
    }
    private int FindToolCellSlot(GameObject givenCellImage)
    {
        for (int i = 0; i < numCells; i++)
        {
            if (cellArray[i].transform.GetChild(0).gameObject == givenCellImage)
            {
                return i;
            }
        }
        return -1;
    }
    public int FindAvailableToolSlot()
    {
        for (int i = 0; i < numCells; i++)
        {
            if (cellArray[i].transform.childCount < 2)
            {
                return i;
            }
        }
        return -1;
    }

    private void Populate()
    {
        cellArray = new GameObject[Mathf.FloorToInt(numCells)];
        for (int i = 0; i < numCells; i++)
        {
            cellArray[i] = CreateCell();
            cellArray[i].name = cellArray[i].name + " " + i;
        }
    }

    private GameObject CreateCell()
    {
        GameObject cell;
        cell = Instantiate(cellPrefab, transform);
        return cell;
    }
}
