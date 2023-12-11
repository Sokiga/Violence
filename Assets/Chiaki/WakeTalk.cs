using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
   

public class Texmanager : MonoBehaviour
{
    public TextAsset dialogDataFile;
    public SpriteRenderer Girl;
    public TMP_Text NameText;
    public TMP_Text Context;
    public Button Next;
    public Canvas Conversation;
    public Animator Player;
    public int dialogIndex;//保存当前对话的索引值
    public string[] dialogRows;
    public bool isSpoken = false;
    private void Start()
    {
        Invoke("ShowDialogRow", 3f);
    }
    public void UpdateText(string _name, string _text)
    {
        NameText.text = _name;
        Context.text = _text;
    }
    public void ReadText(TextAsset _textAsset)
    {
        dialogRows = _textAsset.text.Split('\n');
    }
    public void ShowDialogRow()
    {
        Conversation.gameObject.SetActive(true);
        ReadText(dialogDataFile);
        foreach (var row in dialogRows)
        {
            string[] cell = row.Split(',');
            if (cell[0] == "#" && int.Parse(cell[1]) == dialogIndex)
            {
                Debug.Log(1);
                UpdateText(cell[2], cell[3]);
                Debug.Log(cell[4]);
                dialogIndex = int.Parse(cell[4]);
                Debug.Log(cell[4]);//更新ID
                break;
            }
            if (dialogIndex == 999)
            {
                Conversation.gameObject.SetActive(false);
                Player.SetBool("IsSpoken", isSpoken);
            }
        }
    }
    public void OnClickNext()
    {
        ShowDialogRow();
    }

}
