using BehaviorDesigner.Runtime;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
public class EnemyDesigner : MonoBehaviour
{
    [ReadOnly]
    public MoveType moveType = MoveType.kTrot;
    [ReadOnly]
    public float stopShowMaxTime;
    [ReadOnly]
    public float creepShowMaxTime;
    private float showTime = 0;
    private float showCnt = 0;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    public SharedGameObjectList waypoints;
    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        ResetStatus();
    }
    private void Update()
    {
        SetEnemyOpacity();
    }
    public void ResetStatus()
    {
        moveType = MoveType.kTrot;
        showTime = 0;
        showCnt = 0;
        spriteRenderer.color = new Color(spriteRenderer.color.r,
        spriteRenderer.color.g, spriteRenderer.color.b, 0.0f);
    }
    public void SetStatus(MoveType moveType)
    {
        ResetStatus();
        this.moveType = moveType;
        if (moveType == MoveType.kStop)
        {
            showTime = stopShowMaxTime;
        }
        else if (moveType == MoveType.kCreep)
        {
            showTime = 2 * creepShowMaxTime;
        }
    }
    private void SetEnemyOpacity()
    {
        if (moveType == MoveType.kStop || moveType == MoveType.kCreep)
        {
            showCnt += Time.deltaTime;
            float rotaio = 1.0f;
            if (moveType == MoveType.kStop)
            {
                if (showCnt < showTime) rotaio = showCnt / showTime;
            }
            if (moveType == MoveType.kCreep)
            {
                showCnt %= showTime;
                float showTimeHalf = showTime * 0.5f;
                if (showCnt < showTimeHalf)
                {
                    rotaio = showCnt / showTimeHalf;
                }
                else
                {
                    rotaio = (showTime - showCnt) / showTimeHalf;
                }
            }
            spriteRenderer.color = new Color
                (spriteRenderer.color.r, spriteRenderer.color.g,
                spriteRenderer.color.b, rotaio);
        }
    }
}
