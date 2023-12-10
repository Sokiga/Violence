using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System;

public class SqliteOperation : MonoBehaviour
{
    protected string dataBasePath;
    protected SqliteCommand cmd;
    protected SqliteDataReader reader;
    protected SqliteConnection connection;
    protected virtual void Initial()
    {
        dataBasePath = Const.unityDataBasePath + Const.unityBagDataLocalPath;
        connection = new SqliteConnection(dataBasePath);
        connection.Open();
        cmd = connection.CreateCommand();
    }
    protected virtual void OnApplicationQuit()
    {
        if (reader != null)
        {
            reader.Close();
            reader = null;
        }
        if (cmd != null)
        {
            cmd.Dispose();
            cmd = null;
        }
        if (connection != null)
        {
            connection.Close();
            connection = null;
        }
    }
    public virtual int UpdataDataBase(string cmdContent)
    {
        if(connection == null) Initial();
        Debug.Log(cmdContent);
        cmd.CommandText = cmdContent;
        return cmd.ExecuteNonQuery();
    }
    public virtual int InsertDataBase(string cmdContent)
    {
        if (connection == null) Initial();
        cmd.CommandText = cmdContent;
        return cmd.ExecuteNonQuery();
    }
    public virtual int DeleteDataBase(string cmdContent)
    {
        if (connection == null) Initial();
        cmd.CommandText = cmdContent;
        return cmd.ExecuteNonQuery();
    }
    public virtual object SelectSingleDataBase(string cmdContent)
    {
        if (connection == null) Initial();
        cmd.CommandText = cmdContent;
        return cmd.ExecuteScalar();
    }
    public virtual List<ArrayList> SelectMultipleDataBase(string cmdContent)
    {
        if (connection == null) Initial();
        cmd.CommandText = cmdContent;
        reader = cmd.ExecuteReader();
        List<ArrayList> list = new List<ArrayList>();
        while (reader.Read())
        {
            ArrayList currentRow = new ArrayList();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                currentRow.Add(reader.GetValue(i));
            }
            list.Add(currentRow);
        }
        reader.Close();
        return list;
    }
}
