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
    private float rotationAngle = 60f;
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
        transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
    }
    protected virtual void Update()
    {
        transform.eulerAngles += new Vector3(0, 0, rotationAngle * Time.deltaTime);
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
        float distace = (targetPos - transform.position).magnitude;
        direction = (targetPos - transform.position).normalized;
        float velo = Mathf.Sqrt(distace * 2 * acceler);
        stopTime = velo / (acceler);
        ribi.velocity = velo * direction;
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
        ribi.velocity -= acceler * ribi.velocity.normalized * Time.deltaTime;
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
