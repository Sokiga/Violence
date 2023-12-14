using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using TMPro.Examples;

public class Textmanager : MonoBehaviour
{
    public TextAsset[] dialogDataFile;
    public Image Girl;
    public TMP_Text NameText;
    public TMP_Text Context;
    public Button Next;
    public Canvas Conversation;
    public Animator Player;
    public int dialogIndex;//保存当前对话的索引值
    public int Index;
    public string[] dialogRows;
    public  bool isSpoken = false;
    public List<Sprite>sprites= new List<Sprite>(); 
    Dictionary<string,Sprite> imageDic=new Dictionary<string,Sprite>();
    private void Awake()
    {
        imageDic["!"] = sprites[0];
        imageDic["@"] = sprites[1];
        imageDic["#"]=  sprites[2];
        imageDic["$"] = sprites[3];
        imageDic["%"] = sprites[4];
    }
    private void Start()
    {
        Invoke("ShowDialogRow", 3f);
        UpdateSprite("#");
    }
    private void Update()
    {
        if (isSpoken == true)
        {
            isSpoken = false;
            Index++;
            dialogIndex = 0;
            ShowDialogRow();
        }
    }
    public void UpdateSprite(string _name)
    {
        Girl.sprite = imageDic[_name];
    }
    public void UpdateText(string _name, string _text)
    {
        NameText.text = _name;
        Context.text = _text;

    }
    public void ReadText(TextAsset _textAsset)
    {
        dialogRows = _textAsset.text.Split('\n');
    }//将文本按\n分组
    public void ShowDialogRow()//读取内容并显示
    {
        ReadText(dialogDataFile[Index]);
        foreach (var row in dialogRows)
        {
            string[] cell = row.Split(',');//按逗号进行分组
            if ((cell[0] == "!"|| cell[0] == "@" || cell[0] == "#" || cell[0] == "$" || cell[0] == "%") && int.Parse(cell[1]) == dialogIndex)
            {
                Conversation.gameObject.SetActive(true);
                UpdateText(cell[2], cell[3]);
                UpdateSprite(cell[0]);
                dialogIndex = int.Parse(cell[4]);
                break;
            }
            if (dialogIndex == 999)
            { 
                Conversation.gameObject.SetActive(false);
                Player.SetBool("IsSpoken", isSpoken);
                if (Index == 1)
                {
                    GameObject.Find("Player").GetComponent<PlayerController>().enabled= true;
                    GameObject.Find("FollowCamera").GetComponent<CmeraControl>().enabled = true;
                }
            }
        }
    }
    public void OnClickNext()
    {
        ShowDialogRow();
    }

}
