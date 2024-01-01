using BehaviorDesigner.Runtime;
using System.Collections.Generic;
using TMPro.Examples;
using Unity.Collections;
using UnityEditor.Rendering;
using UnityEngine;
public enum SoundType
{
    kNone,
    kStone,
    kTrot,
    kBottle,
    kRun
}
public enum MoveType
{
    kStop,
    kCreep,
    kTrot,
    kRun
}
public class PlayerController : MonoBehaviour
{
    public List<GameObject> enemyTarget;
    public SoundType soundType = SoundType.kNone;
    public MoveType moveType = MoveType.kCreep;
    public SharedVector3 targetPos;
    public GameObject preepPrefabs;
    public SharedFloat targetRange;
    public bool isOpening = false;
    public float[] SoundRange;
    public bool isSendEvent;
    public bool isShowCircle = true;
    public bool isStopMove = false;
    public bool isOpenBag = false;
    public bool isOpenPlane = false;
    public bool isHasKey = false;
    public AudioClip runClip;
    public BagOperation bagOperation;
    private AudioSource audioSource;
    private BehaviorTree bt;
    private SharedBool IsSendEvent;
    private bool isShowLine = false;
    private List<EnemyDesigner> enemyDesinger;
    private Rigidbody2D rb;
    private Animator animator;
    private GameObject particleSystemForSon;
    private bool isStartMove = false;
    private float openBagMaxTime = 1.0f;
    private float openBagTime = 0f;
    private DamageController damageController;
    [SerializeField]
    private GameObject line;
    [SerializeField]
    private GameObject circle;
    [SerializeField]
    private float throwMaxRadius;
    [SerializeField]
    private float kStopShowMaxTime;
    [SerializeField]
    private float kCreepShowMaxTime;
    [SerializeField]
    private Canvas bagCanvas;
    [SerializeField]
    private GameObject planePrefabs;
    [SerializeField]
    private CmeraControl cameraCtrl;
    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        bt = GetComponent<BehaviorTree>();
        damageController = GetComponent<DamageController>();
        preepPrefabs = Resources.Load<GameObject>("Prefabs/Stone");
        IsSendEvent = false;
        line.SetActive(false);
        circle.SetActive(false);
        rb=GetComponent<Rigidbody2D>();
        enemyDesinger = new List<EnemyDesigner>();
        for (int i = 0; i < enemyTarget.Count; i++)
        {
            enemyDesinger.Add(enemyTarget[i].GetComponent<EnemyDesigner>());
            enemyDesinger[i].stopShowMaxTime = kStopShowMaxTime;
            enemyDesinger[i].creepShowMaxTime = kCreepShowMaxTime;
        }
        isSendEvent = true;
        animator = GetComponent<Animator>();
        particleSystemForSon = GameObject.Find("ParticleSystem");
    }

    private void Update()
    {
        CheckIsMadeSound();
        Spawn();
        if (isShowLine)
        {
            ShowLine();
            animator.SetBool("IsPrepare", true);
        }
        else
        {
            animator.SetBool("IsPrepare", false);
        }
        ShowEnemyOpacityStatus();
        animator.SetInteger("MoveType", (int)moveType);
        if(!isStopMove) TurnPlayerDiraction();
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerRise"))
        {
            if(!isStartMove)
            {
                isStartMove = true;
                isStopMove = false;
            }
        }
        if (moveType == MoveType.kCreep)
        {
            if (particleSystemForSon.gameObject.activeInHierarchy == true)
            {
                particleSystemForSon.SetActive(false);
            }
        }
        else
        {
            if (particleSystemForSon.gameObject.activeInHierarchy == false)
            {
                particleSystemForSon.SetActive(true);
            }
        }
    }
    public void SendEventToEnemy(SoundType soundType, Vector3 targetPos)
    {
        IsSendEvent = true;
        bt.SetVariable("IsSendEvent", IsSendEvent);
        this.soundType = soundType;
        targetRange.SetValue(SoundRange[(int)soundType]);
        this.targetPos.SetValue(targetPos);
        bt.SetVariable("targetPos", this.targetPos);
        bt.SetVariable("targetRange", this.targetRange);
    }
    public void UnSetEvent()
    {
        if (isSendEvent)
        {
            IsSendEvent = false;
            bt.SetVariable("IsSendEvent", IsSendEvent);
            targetPos.SetValue(Vector3.zero);
            targetRange.SetValue(0.0f);
            bt.SetVariable("targetPos", this.targetPos);
            bt.SetVariable("targetRange", this.targetRange);
        }
    }
    private void CheckIsMadeSound()
    {
        if (moveType == MoveType.kTrot)
        {
            SendEventToEnemy(SoundType.kTrot, transform.position);
        }
        else if (moveType == MoveType.kRun)
        {
            SendEventToEnemy(SoundType.kRun, transform.position);
        }
        else
        {
            soundType = SoundType.kNone;
            UnSetEvent();
        }
    }
    private void OnDrawGizmos()
    {
#if UNITY_EDITOR
        var oldColor = UnityEditor.Handles.color;
        UnityEditor.Handles.color = Color.yellow;
        UnityEditor.Handles.SphereHandleCap(0, transform.position, transform.rotation, SoundRange[(int)soundType], EventType.Repaint);
        UnityEditor.Handles.color = oldColor;
#endif
    }
    private void Spawn()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if ((damageController.attackWayType == EnumAttackWay.kStone && bagOperation.stonePrefabs.Count != 0) ||
                (damageController.attackWayType == EnumAttackWay.kBottle && bagOperation.bottlePrefabs.Count != 0))
                isShowLine = true;
        }
        if(Input.GetMouseButtonUp(1)) 
        { 
            isShowLine = false;
            line.SetActive(false);
            circle.SetActive(false);
        }
        if (Input.GetMouseButtonUp(0) && isShowLine)
        {
            animator.SetBool("IsThrow", true);
            animator.SetBool("IsPrepare", false);
            if (damageController.attackWayType == EnumAttackWay.kStone) bagOperation.DeleteBagData(0);
            else bagOperation.DeleteBagData(1);
            var temp = GameObject.Instantiate(preepPrefabs, transform);
            Vector3 offset = CalculatePreepVec();
            temp.transform.localPosition = Vector3.zero;
            temp.GetComponent<PreepController>().targetPos = offset;
            isShowLine = false;
            line.SetActive(false);
            circle.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Tab)) 
        {
            isOpening = true;
        }
        if(Input.GetKeyUp(KeyCode.Tab))
        {
            if (openBagTime > openBagMaxTime || isOpenBag)
            {
                isOpenBag = !isOpenBag;
                OpenOrCloseBag(isOpenBag);
            }
            else
            {
                isOpenPlane = !isOpenPlane;
                OpenOrClosePlane(isOpenPlane);
            }
            openBagTime = 0;
            isOpening = false;
        }
        if (isOpening)
        {
            openBagTime += Time.deltaTime;
        }
        else
        {
            openBagTime = 0;
        }
    }
    private Vector3 CalculatePreepVec()
    {
        Vector3 mouseWorldPostion = GetMouseWorldPostion();
        mouseWorldPostion -= transform.position;
        if (mouseWorldPostion.magnitude > throwMaxRadius)
        {
            float ratio = throwMaxRadius / mouseWorldPostion.magnitude;
            mouseWorldPostion = Vector3.Lerp(Vector3.zero, mouseWorldPostion, ratio);
        }
        return mouseWorldPostion + transform.position;
    }
    private void ShowLine()
    {
        line.SetActive(true);
        if(isShowCircle) circle.SetActive(true);
        Vector3 throwPos = CalculatePreepVec();
        line.GetComponent<LineRenderer>().SetPosition(0, transform.position);
        line.GetComponent<LineRenderer>().SetPosition(1, throwPos);
        circle.transform.position = throwPos;
    }
    private bool IsInView(Vector3 worldPos)
    {
        Transform camTransform = Camera.main.transform;
        Vector2 viewPos = Camera.main.WorldToViewportPoint(worldPos);
        Vector3 dir = (worldPos - camTransform.position).normalized;
        float dot = Vector3.Dot(camTransform.forward, dir);
        if (dot > 0 && viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1) return true;
        else return false;
    }
    private void ShowEnemyOpacityStatus()
    {
        for (int i = 0; i < enemyDesinger.Count; i++)
        {
            if (enemyDesinger[i].moveType != this.moveType && IsInView(enemyTarget[i].transform.position))
            {
                enemyDesinger[i].SetStatus(this.moveType);
            }
        }
    }
    private void TurnPlayerDiraction()
    {
        Vector3 mouseWorldPostion = GetMouseWorldPostion();
        transform.up = mouseWorldPostion - transform.position;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
    }
    public Vector3 GetMouseWorldPostion()
    {
        Vector3 mouseWorldPostion = Input.mousePosition;
        mouseWorldPostion.z = Mathf.Abs(Camera.main.transform.position.z);
        mouseWorldPostion = Camera.main.ScreenToWorldPoint(mouseWorldPostion);
        return mouseWorldPostion;
    }
    private void OpenOrCloseBag(bool isOpen)
    {
        if(isOpen)
        {
            bagCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
            isStopMove = true;
            Time.timeScale = 0;
            cameraCtrl.isFunction = false;
        }
        else
        {
            bagCanvas.renderMode = RenderMode.WorldSpace;
            isStopMove = false;
            Time.timeScale = 1.0f;
            cameraCtrl.isFunction = true;
        }
    }
    private void OpenOrClosePlane(bool isOpen)
    {
        if(isOpen)
        {
            planePrefabs.SetActive(true);
            Time.timeScale = 0;
            cameraCtrl.isFunction = false;
            isStopMove = true;
        }
        else
        {
            planePrefabs.SetActive(false);
            Time.timeScale = 1.0f;
            cameraCtrl.isFunction = true;
            isStopMove = false;
        }
    }
    public void OnPlayerExite()
    {
        animator.SetBool("IsThrow", false);
    }
    public void MakeSound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}


