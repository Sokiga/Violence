using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;

public class PropController : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
{

    public string[] memoryArray;
    private BagOperation bagOperation;
    private CreatedGrid gridData;
    private Transform transformForLast;
    private GridLayoutGroup layoutGroup;
    private RectTransform rectTransform;
    private Vector3 mouseOffset = Vector3.zero;
    private int[,] gridObjHave;
    private Canvas canvas;
    private bool isChangeRota = false;
    private Tuple<int, int> lastPos = new Tuple<int, int>(0, 0);
    private Tuple<int, int> lastRect = new Tuple<int, int>(0, 0);
    private float RotaTime;
    private float RotaMaxTime = 0.2f;
    private Dictionary<int, Tuple<int, int>> dic;
    private Tuple<int, int> lastDic = new Tuple<int, int>(0, 0);
    private int lastRota = 0;
    private void Start()
    {
        bagOperation= gameObject.GetComponentInParent<BagOperation>();
        gridData = gameObject.GetComponentInParent<CreatedGrid>();
        layoutGroup = gameObject.GetComponentInParent<GridLayoutGroup>();
        rectTransform = gameObject.GetComponent<RectTransform>();
        canvas = gameObject.GetComponent<Canvas>();
        gridObjHave = gridData.gridObjHave;
        transformForLast = transform.parent;
        transform.localPosition = Vector3.zero;

        for (int i = 0; i < gridData.maxCol; ++i)
        {
            for (int j = 0; j < gridData.maxRow; ++j)
            {
                if (gridData.gridObjData[i, j].transform == transformForLast)
                {
                    lastPos = Tuple.Create(i, j);
                }
            }
        }
        for (int i = 0; i < memoryArray.Length; i++)
        {
            for (int j = 0; j < memoryArray[i].Length; j++)
            {
                if (memoryArray[i][j] != '0')
                {
                    if (memoryArray[i][j] == '2') lastRect = Tuple.Create(i, j);
                }
            }
        }
        RotaTime = 0f;
        dic = new Dictionary<int, Tuple<int, int>>();
        dic.Add(90, new Tuple<int, int>(-1, 1));
        dic.Add(270, new Tuple<int, int>(-1, -1));
        dic.Add(0, new Tuple<int, int>(0, 0));
        dic.Add(180, new Tuple<int, int>(-2, 0));
        lastRota = (int)transform.eulerAngles.z;
        lastDic = dic[lastRota];
        List<Tuple<int, int>> propMemory = GetLoaclTuple(lastRect);
        for (int i = 0; i < propMemory.Count; ++i)
        {
            int tmpx = propMemory[i].Item1 + lastPos.Item1, tmpy = propMemory[i].Item2 + lastPos.Item2;
            if (i != 0)
            {
                tmpx += dic[(int)transform.eulerAngles.z].Item1;
                tmpy += dic[(int)transform.eulerAngles.z].Item2;
            }
            gridObjHave[tmpx, tmpy] = 1;
            gridData.gridObjData[tmpx, tmpy].GetComponentInChildren<TextMeshProUGUI>().text = "1";

        }

    }
    private void Update()
    {

        if (isChangeRota)
        {
            if (RotaTime > RotaMaxTime && ChangeRotation())
            {
                RotaTime = 0f;
            }
            else RotaTime += Time.deltaTime;
        }
        else RotaTime = 0f;
    }
    public void OnDrag(PointerEventData eventData)
    {
        canvas.sortingOrder = 100;
        transform.position = Input.mousePosition;
        transform.SetAsFirstSibling();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Tuple<int, int> tuple;
        if (CheckIsInGrid(transform.position, out tuple, rectTransform) && tuple != null && CheckFair(tuple))
        {
            transform.SetParent(gridData.gridObjData[tuple.Item1, tuple.Item2].transform);
            transformForLast = gridData.gridObjData[tuple.Item1, tuple.Item2].transform;
            transform.localPosition = Vector3.zero;
            lastPos = tuple;
        }
        else
        {
            transform.SetParent(transformForLast);
            transform.localPosition = Vector3.zero;
        }
        canvas.sortingOrder = 1;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isChangeRota = true;
    }

    private bool CheckFair(Tuple<int, int> dragPos)
    {
        List<Tuple<int, int>> propMemory = GetLoaclTuple(lastRect);
        for (int i = 0; i < propMemory.Count; ++i)
        {
            int tmpx = propMemory[i].Item1 + dragPos.Item1, tmpy = propMemory[i].Item2 + dragPos.Item2;
            if (i != 0)
            {
                tmpx += dic[(int)transform.eulerAngles.z].Item1;
                tmpy += dic[(int)transform.eulerAngles.z].Item2;
            }
            if (tmpx < 0 || tmpx >= gridData.maxCol || tmpy < 0 || tmpy >= gridData.maxRow)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, lastRota);
                return false;
            }
            if (gridObjHave[tmpx, tmpy] != 0)
            {
                bool flag = false;
                for (int j = 0; j < propMemory.Count; ++j)
                {
                    int retx = propMemory[j].Item1 + lastPos.Item1, rety = propMemory[j].Item2 + lastPos.Item2;
                    if (tmpx == retx && tmpy == rety) flag = true;
                }
                if (flag == false) return false;
            }
        }
        for (int i = 0; i < propMemory.Count; ++i)
        {
            int tmpx = propMemory[i].Item1 + lastPos.Item1, tmpy = propMemory[i].Item2 + lastPos.Item2;
            if (i != 0)
            {
                tmpx += lastDic.Item1;
                tmpy += lastDic.Item2;
            }
            if (tmpx < 0 || tmpx >= gridData.maxCol || tmpy < 0 || tmpy >= gridData.maxRow)
            {
                continue;
            }
            gridObjHave[tmpx, tmpy] = 0;
            gridData.gridObjData[tmpx, tmpy].GetComponentInChildren<TextMeshProUGUI>().text = "0";
        }
        bagOperation.ResetBagData(lastPos.Item1, lastPos.Item2);
        lastDic = dic[(int)transform.eulerAngles.z];
        lastRota = (int)transform.eulerAngles.z;
        for (int i = 0; i < propMemory.Count; ++i)
        {
            int tmpx = propMemory[i].Item1 + dragPos.Item1, tmpy = propMemory[i].Item2 + dragPos.Item2;
            if (i != 0)
            {
                tmpx += dic[(int)transform.eulerAngles.z].Item1;
                tmpy += dic[(int)transform.eulerAngles.z].Item2;
            }
            if (tmpx < 0 || tmpx >= gridData.maxCol || tmpy < 0 || tmpy >= gridData.maxRow)
            {
                continue;
            }
            gridObjHave[tmpx, tmpy] = 1;
            gridData.gridObjData[tmpx, tmpy].GetComponentInChildren<TextMeshProUGUI>().text = "1";

        }
        if (propMemory.Count == 1)
        {
            bagOperation.ChangeBagData(lastRota, PropType.kStone, propMemory[0].Item1 + dragPos.Item1, propMemory[0].Item2 + dragPos.Item2);
        }
        else
        {
            bagOperation.ChangeBagData(lastRota, PropType.kBottle, propMemory[0].Item1 + dragPos.Item1, propMemory[0].Item2 + dragPos.Item2);
        }
        return true;
    }
    private bool CheckIsInGrid(Vector3 target, out Tuple<int, int> tuple, RectTransform rect)
    {
        for (int i = 0; i < gridData.maxCol; ++i)
        {
            for (int j = 0; j < gridData.maxRow; ++j)
            {
                float posX = rect.rect.width * 0.5f + target.x;
                float posY = rect.rect.height * 0.5f + target.y;
                if (gridData.gridObjData[i, j].transform.position.x < posX &&
                   posX < gridData.gridObjData[i, j].transform.position.x + layoutGroup.cellSize.x)
                {
                    if (gridData.gridObjData[i, j].transform.position.y < posY &&
                    posY < gridData.gridObjData[i, j].transform.position.y + layoutGroup.cellSize.y)
                    {
                        tuple = new Tuple<int, int>(i, j);
                        return true;
                    }
                }
            }
        }
        tuple = null;
        return false;
    }
    private List<Tuple<int, int>> GetLoaclTuple(Tuple<int, int> initialPos)
    {
        List<Tuple<int, int>> propMemory = new List<Tuple<int, int>>();
        propMemory.Add(Tuple.Create(0, 0));
        for (int i = 0; i < memoryArray.Length; ++i)
        {
            for (int j = 0; j < memoryArray[i].Length; ++j)
            {
                if (memoryArray[i][j] == '1')
                {
                    propMemory.Add(Tuple.Create(i - initialPos.Item1, j - initialPos.Item2));
                }
            }
        }
        return propMemory;
    }
    private bool ChangeRotation()
    {
        if (Input.GetKey(KeyCode.A)) transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - 90);
        else if (Input.GetKey(KeyCode.D)) transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 90);
        else return false;
        return true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isChangeRota = false;
        OnEndDrag(eventData);
    }
}
