using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class StraddletheObstacle : MonoBehaviour
{
    // Start is called before the first frame update
    /*    [SerializeField] float S_Force;*/
    private float elapsedTime;
    private bool isCrossing = false;
    private int a = 1;
    [SerializeField] float crossSpeed;
    public Rigidbody2D rb;
    public Collider2D Player;
    public float crossTime = 3f;// 设置穿越时间为2秒
    public Animator playerAnimator; // 玩家的动画控制器
    public Camera _camera;
    public Transform Target;
    public Transform BackTarget;
    public LayerMask playerLayer;
    public LayerMask obstacleLayer;

    private void Update()
    {
        if (isCrossing == true)
        {float step=crossSpeed* Time.deltaTime;
            elapsedTime += Time.deltaTime;

            if (elapsedTime < crossTime)
            {if(a==1)
                rb.transform.position = Vector3.Lerp(rb.transform.position, Target.position, step);
            else if(a==-1)
                rb.transform.position = Vector3.Lerp(rb.transform.position, BackTarget.position, step);
            }
            
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCrossing&&Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(CrossOverTime(other.GetComponent<PlayerController>(),_camera.GetComponent<CmeraControl>()));
        }
    }
    IEnumerator CrossOverTime(PlayerController playercontroller,CmeraControl CameraControl)
    {
        Physics2D.IgnoreLayerCollision(3, 8, true);
        isCrossing = true;
        playercontroller.isStopMove = true;
        CameraControl.enabled = false;
        float t=crossTime;
        // 播放穿墙动画
        playerAnimator.SetTrigger("CrossOver");

        // 等待一定时间
        yield return new WaitForSeconds(crossTime);

        // 跨越时间结束后，恢复玩家的移动能力
        elapsedTime = 0;
        Physics2D.IgnoreLayerCollision(3, 8, false);
        isCrossing = false;
        playercontroller.isStopMove = false;
        CameraControl.enabled = true;
        a = -a;
        crossTime = t;

        // 恢复到站立动画
        playerAnimator.SetTrigger("Idle");
    }
}



