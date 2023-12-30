using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PropType
{
    kStone,
    kBottle,
    kNone
};
public class BagOperation : MonoBehaviour
{
    private SqliteOperation sqliteOperation;
    public List<GameObject> stonePrefabs = new List<GameObject>();
    public List<GameObject> bottlePrefabs = new List<GameObject>();
    public void ChangeBagData(int lastRota, PropType propType, int col, int row)
    {
        if (sqliteOperation == null) sqliteOperation = GetComponent<SqliteOperation>();
        string data = string.Format("{0}-{1}", lastRota, (int)propType);
        string cmd = string.Format("Update BagDataBase Set column{0} = '{1}' Where rowid = '{2}'", row + 1, data, col + 1);
        sqliteOperation.UpdataDataBase(cmd);
    }
    public void ResetBagData(int col,int row)
    {
        if (sqliteOperation == null) sqliteOperation = GetComponent<SqliteOperation>();
        string data = string.Format("Update BagDataBase Set column{0} = '0' Where rowid = '{1}'", row + 1, col + 1);
        sqliteOperation.UpdataDataBase(data);
    }
    public bool UpdateBagData(int col, int row,GameObject parent)
    {
        if (sqliteOperation == null) sqliteOperation = GetComponent<SqliteOperation>();
        string cmd = string.Format("Select column{0} From BagDataBase Where rowid = '{1}'", row + 1, col + 1);
        string str = sqliteOperation.SelectSingleDataBase(cmd) as string;
        if (str != "0")
        {
            GameObject @object;
            if (str[str.Length - 1] == '0') @object = Resources.Load("Perfabs/Stone") as GameObject;
            else @object = Resources.Load("Perfabs/Bottle") as GameObject;
            GameObject prop = GameObject.Instantiate(@object);
            prop.GetComponent<PropController>().gridData = this.GetComponent<CreatedGrid>();
            prop.transform.SetParent(parent.transform);
            prop.transform.position = Vector3.zero;
            string tmp = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != '-') tmp += str[i];
                else break;
            }
            if (str[str.Length - 1] == '0') stonePrefabs.Add(prop);
            else bottlePrefabs.Add(prop);
            prop.transform.eulerAngles = new Vector3(prop.transform.eulerAngles.x, prop.transform.eulerAngles.y, Convert.ToInt32(tmp));
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool DeleteBagData(int propType)
    {
        if (propType == 0)
        {
            if (stonePrefabs.Count == 0) return false;
            GameObject obj = stonePrefabs[stonePrefabs.Count - 1];
            stonePrefabs.Remove(obj);
            obj.GetComponent<PropController>().DeleteProp();
            Destroy(obj);
        }
        else if(propType == 1) 
        {
            if(bottlePrefabs.Count == 0) return false;
            GameObject obj = bottlePrefabs[bottlePrefabs.Count - 1];
            bottlePrefabs.Remove(obj);
            obj.GetComponent<PropController>().DeleteProp();
            Destroy(obj);
        }
        return true;
    }
}
