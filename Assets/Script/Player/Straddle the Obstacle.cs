using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StraddletheObstacle : MonoBehaviour
{
    // Start is called before the first frame update
    /*    [SerializeField] float S_Force;*/
    private float elapsedTime;
    private bool isCrossing = false;
    [SerializeField] float crossSpeed;
    public Rigidbody2D rb;
    public Collider2D Player;
    public float crossTime = 3f;// 设置穿越时间为2秒
    public Animator playerAnimator; // 玩家的动画控制器
    public Camera _camera;
    public Transform Target;

   /* private void Start()
    {
        startingposition = rb.transform.position;
    }*/
    private void Update()
    {
        Debug.Log(transform.position);
        if (isCrossing == true)
        {float step=crossSpeed* Time.deltaTime;
            elapsedTime += Time.deltaTime;

            if (elapsedTime < crossTime)
            {
                rb.transform.position = Vector3.Lerp(rb.transform.position, Target.position, step);
            }
            else
            {
                transform.position = Target.position;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCrossing&&Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F pressed");
            StartCoroutine(CrossOverTime(other.GetComponent<PlayerController>(),_camera.GetComponent<CmeraControl>()));
        }
    }
    IEnumerator CrossOverTime(PlayerController playercontroller,CmeraControl CameraControl)
    {   Player.isTrigger=true;
        isCrossing = true;
        playercontroller.isStopMove = true;
        CameraControl.enabled = false;
        // 播放穿墙动画
        playerAnimator.SetTrigger("CrossOver");

        // 等待一定时间
        yield return new WaitForSeconds(crossTime);

        // 跨越时间结束后，恢复玩家的移动能力
        Player.isTrigger = false;
        isCrossing = false;
        playercontroller.isStopMove = false;
        CameraControl.enabled = true;
        Target.position=-Target.position;

        // 恢复到站立动画
        playerAnimator.SetTrigger("Idle");
    }
}



