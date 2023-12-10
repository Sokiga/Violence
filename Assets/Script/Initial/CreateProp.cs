using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreateProp : MonoBehaviour
{
    private CreatedGrid createdGrid;
    private BagOperation bagOperation;
    private void Start()
    {
        createdGrid = GetComponent<CreatedGrid>();
        bagOperation = GetComponent<BagOperation>();
    }
    private bool FindGrid(PropType propType, out Tuple<int, int> gridPos)
    {
        for (int i = 0; i < createdGrid.maxCol; ++i)
        {
            for (int j = 0; j < createdGrid.maxRow; ++j)
            {
                if (propType == PropType.kBottle)
                {
                    if (i != createdGrid.maxCol - 1 && createdGrid.gridObjHave[i, j] == 0 && createdGrid.gridObjHave[i + 1, j] == 0)
                    {
                        gridPos = Tuple.Create(i, j);
                        return true;
                    }
                }
                else if (propType == PropType.kStone)
                {
                    if (createdGrid.gridObjHave[i, j] == 0)
                    {
                        gridPos = Tuple.Create(i, j);
                        return true;
                    }
                }
            }
        }
        Debug.Log(1);
        gridPos = null;
        return false;
    }
    public void CreatePropForBag(int prop)
    {
        PropType propType=(PropType)prop;
        Tuple<int, int> gridPos;
        if(FindGrid(propType, out gridPos))
        {
            GameObject prefabs;
            if(propType==PropType.kStone)
            {
                prefabs = Resources.Load("Perfabs/Stone") as GameObject;
                GameObject obj = GameObject.Instantiate(prefabs);
                obj.transform.SetParent(createdGrid.gridObjData[gridPos.Item1, gridPos.Item2].transform);
                createdGrid.gridObjHave[gridPos.Item1, gridPos.Item2] = 1;
                createdGrid.gridObjData[gridPos.Item1, gridPos.Item2].GetComponentInChildren<TextMeshProUGUI>().text = "1";
            }
            else
            {
                prefabs = Resources.Load("Perfabs/Bottle") as GameObject;
                GameObject obj = GameObject.Instantiate(prefabs);
                obj.transform.SetParent(createdGrid.gridObjData[gridPos.Item1, gridPos.Item2].transform);
                createdGrid.gridObjHave[gridPos.Item1, gridPos.Item2] = 1;
                createdGrid.gridObjHave[gridPos.Item1 + 1, gridPos.Item2] = 1;
                createdGrid.gridObjData[gridPos.Item1, gridPos.Item2].GetComponentInChildren<TextMeshProUGUI>().text = "1";
                createdGrid.gridObjData[gridPos.Item1 + 1, gridPos.Item2].GetComponentInChildren<TextMeshProUGUI>().text = "1";
            }
            bagOperation.ChangeBagData(0, propType, gridPos.Item1, gridPos.Item2);
            //return true;
        }
        else 
        { 
            //return false;
        }

    }
}
