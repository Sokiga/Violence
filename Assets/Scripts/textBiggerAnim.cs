using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textBiggerAnim : MonoBehaviour
{
    // Start is called before the first frame update
    private Text textChange;
    private bool isChange = false;
    private int changeSize = 50;
    private void Start()
    {
        textChange = GetComponentInChildren<Text>();
    }
    private void Update()
    {
        if (isChange && textChange.fontSize != changeSize)
        {
            Mathf.Lerp(textChange.fontSize, changeSize, 0.1f);
            if (textChange.fontSize - changeSize < 0.05f)
            {
                textChange.fontSize = changeSize;
            }
        }
    }
    public void ChangeFontSize()
    {
        isChange = true;
    }
}
