using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatedGrid : MonoBehaviour
{
    [Header("�������")]
    public int maxRow = 10;
    [Header("�������")]
    public int maxCol = 5;
    //����������Ϣ
    [ReadOnly]
    public GameObject[,] gridObjData;
    [ReadOnly]
    public int[,] gridObjHave;
    //��������
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
