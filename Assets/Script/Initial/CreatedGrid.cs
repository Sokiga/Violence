using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatedGrid : MonoBehaviour
{
    [Header("最大行数")]
    public int maxRow = 10;
    [Header("最大列数")]
    public int maxCol = 5;
    //格子数据信息
    [ReadOnly]
    public GameObject[,] gridObjData;
    [ReadOnly]
    public int[,] gridObjHave;
    //背包格子
    private GameObject gridObjPrefabs;
    private BagOperation bagOperation;
    private void Awake()
    {
        bagOperation = GetComponent<BagOperation>();
        gridObjPrefabs = Resources.Load("Perfabs/Grid") as GameObject;
        gridObjData = new GameObject[maxCol, maxRow];
        gridObjHave = new int[maxCol, maxRow];
        for (int i = 0; i < maxCol; i++)
        {
            for (int j = 0; j < maxRow; j++)
            {
                gridObjData[i, j] = Instantiate(gridObjPrefabs);
                gridObjData[i, j].transform.SetParent(transform);
                if(bagOperation.UpdateBagData(i, j, gridObjData[i, j]))
                {
                    gridObjData[i, j].GetComponentInChildren<PropController>().gridObjHave = gridObjHave;
                    gridObjData[i, j].GetComponentInChildren<PropController>().createProp = GetComponent<CreateProp>();
                }
            }
        }
        
    }
}
