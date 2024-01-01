using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Playables;


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
    public  bool hasSpoken = false;
    public List<Sprite>sprites= new List<Sprite>(); 
    public PlayableDirector MouseAppear;
    public PlayableDirector MouseDie;
    public PlayableDirector PlayerSave;
    public PlayableDirector PlayerDied;
    Dictionary<string,Sprite> imageDic=new Dictionary<string,Sprite>();
    private bool isSpeaking = true;
    private bool heard = false;
    private bool saw = false;
    private bool run = false;
    private bool die = false;
    private void Awake()
    {
        imageDic["!"] = sprites[0];
        imageDic["@"] = sprites[1];
        imageDic["#"]=  sprites[2];
        imageDic["$"] = sprites[3];
        imageDic["%"] = sprites[4];
        imageDic["^"]= sprites[5];
    }
    private void Start()
    {
        /*playabledirector.paused += OnTimeLinePaused;*/
        //MouseAppear.played += OnTimeLine;
        //MouseDie.played += OnTimeLine;
  
        //PlayerDied.played += OnTimeLine;
        MouseDie.stopped += OnTimeLineFinshed;
        MouseAppear.stopped += OnTimeLineFinshed;
        PlayerSave.stopped += OnTimeLineFinshed;
        PlayerDied.stopped += OnTimeLineFinshed;
        Invoke("ShowDialogRow", 3f);
    }
    private void Update()
    {
        Debug.Log(1);
        if (hasSpoken == true)
        {
            Debug.Log(1);
            hasSpoken = false;
            Index=Index+1;
            dialogIndex = 0;
            ShowDialogRow();
            
        }
        //让玩家对话时无法移动
        if (isSpeaking == false)
        {
            GameObject.Find("Player").GetComponent<PlayerController>().isStopMove= false;
        }
        else if (isSpeaking == true)
        {
            GameObject.Find("Player").GetComponent<PlayerController>().isStopMove = true;
        }
        if (Index == 2 && dialogIndex == 999&&!heard)
        {
            heard = true;
            MouseAppear.Play();
            Invoke("Speak", 3.5f);
        }
        if(Index == 4 && dialogIndex == 3 && !saw)
        {
            saw = true;
            PlayerDied.Play();
        }
        if(Index==4&& dialogIndex == 999 && !run)
        {
            run = true;
            Destroy(PlayerDied); PlayerDied = null;
            PlayerSave.Play();
        }        
        if(Index==6&&dialogIndex==999&&!die)
        {
            Player.SetTrigger("Die");
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
        isSpeaking = true;
        ReadText(dialogDataFile[Index]);
        foreach (var row in dialogRows)
        {
            string[] cell = row.Split(',');//按逗号进行分组
            if ((cell[0] == "!"|| cell[0] == "@" || cell[0] == "#" || cell[0] == "$" || cell[0] == "%" || cell[0]=="^" )&& int.Parse(cell[1]) == dialogIndex)
            {
                
                Conversation.gameObject.SetActive(true);
                UpdateText(cell[2], cell[3]);
                UpdateSprite(cell[0]);
                dialogIndex = int.Parse(cell[4]);
                break;
            }
            if (dialogIndex == 999)
            {
                isSpeaking = false;
                Conversation.gameObject.SetActive(false);
                Player.SetBool("IsSpoken", false);
            }
            
        }
    }
    public void OnClickNext()
    {
        ShowDialogRow();
    }

    void OnTimeLineFinshed(PlayableDirector director)
    {
        if(director==MouseAppear)
        {
            MouseDie.Play();
        }
         if (director == MouseDie)
        {
            hasSpoken = true;
        }
         if (director == PlayerDied)
        {
            Index = 5; hasSpoken = true;

        }
         if (director == PlayerSave)
        {
            hasSpoken = true; 
        }
    }
    
    //void OnTimeLine(PlayableDirector director)
    //{
    //        GameObject.Find("Player").GetComponent<PlayerController>().isStopMove =true;
    // }
    /*
    void OnTimeLinePaused(PlayableDirector director)
    {if (director == playabledirector)
        {
            hasSpoken = true;
        }
    }
    void TimeLinePaused()
    {
        Debug.Log(1);
           playabledirector.Pause();
    }
   */
    private void Speak()
    {
        hasSpoken = true;
    }
}
