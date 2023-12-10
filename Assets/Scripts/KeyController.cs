using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public int keyCodeSize = 12;
    private KeyCode[] keyCode;
    private void Start()
    {
        keyCode = new KeyCode[keyCodeSize];
        keyCode[0] = KeyCode.W;
        keyCode[1] = KeyCode.S;
        keyCode[2] = KeyCode.A;
        keyCode[3] = KeyCode.D;
        keyCode[4] = KeyCode.LeftControl;
        keyCode[5] = KeyCode.LeftShift;
        keyCode[6] = KeyCode.Space;
        keyCode[7] = KeyCode.F;
        keyCode[8] = KeyCode.Mouse0;
        keyCode[9] = KeyCode.Mouse2;
        keyCode[10] = KeyCode.Q;
        keyCode[11] = KeyCode.Tab;
        for (int i = 0; i < keyCodeSize; i++)
        {
            string str = string.Format("{0}-{1}", keyCode.ToString(), i);
            if (PlayerPrefs.HasKey(str))
            {
                keyCode[i] = (KeyCode)PlayerPrefs.GetInt(str);
            }
            else
            {
                PlayerPrefs.SetInt(str, (int)keyCode[i]);
            }
        }
    }
    public void ChangeKey()
    {
        KeyCode changeKey;
        foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
            {
                changeKey = kcode;
            }
        }

    }
}
