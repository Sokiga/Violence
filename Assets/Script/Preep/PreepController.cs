using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Rendering.Universal;

public class PreepController : MonoBehaviour
{
    public Vector3 targetPos;
    public float destroyTime;
    public float stopTime;
    public SoundType soundType;
    public float acceler = 5.0f;
    private Vector3 direction;
    private float destroyCnt;
    private Rigidbody2D ribi;
    private SpriteRenderer spriteRenderer;
    private new Collider2D collider;
    private bool isSendMsg = false;
    protected virtual void Start()
    {
        soundType = SoundType.kStone;
        destroyCnt = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
        ribi = GetComponent<Rigidbody2D>();
        CalculateVelocity();
        transform.SetParent(null, true);
        destroyTime = stopTime + 5f;
    }
    protected virtual void Update()
    {
        if (destroyCnt < destroyTime)
        {
            OnCntLessDestrory();
        }
        else
        {
            OnCntGreaterDestrory();
        }
        if (destroyCnt < stopTime)
        {
            OnCntLessStop();
        }
        else
        {
            if (!isSendMsg)
            {
                OnCntGreaterStop();
            }
        }
    }
    protected virtual void CalculateVelocity()
    {
        direction = (targetPos - transform.position).normalized;
        ribi.velocity = 8.5f * direction;
        float distace = (targetPos - transform.position).magnitude;
        stopTime = distace / ribi.velocity.magnitude;
    }
    protected virtual void OnCntLessDestrory()
    {
        destroyCnt += Time.deltaTime;
    }
    protected virtual void OnCntGreaterDestrory()
    {
        Destroy(gameObject);
    }
    protected virtual void OnCntLessStop()
    {
    }
    protected virtual void OnCntGreaterStop()
    {
        ribi.velocity = Vector3.zero;
        isSendMsg = true;
        spriteRenderer.color = new Color(
        spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.0f);
        collider.enabled = false;

    }
}
