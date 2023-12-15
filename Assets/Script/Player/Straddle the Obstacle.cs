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
    public float crossTime = 3f;// ���ô�Խʱ��Ϊ2��
    public Animator playerAnimator; // ��ҵĶ���������
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
        // ���Ŵ�ǽ����
        playerAnimator.SetTrigger("CrossOver");

        // �ȴ�һ��ʱ��
        yield return new WaitForSeconds(crossTime);

        // ��Խʱ������󣬻ָ���ҵ��ƶ�����
        Player.isTrigger = false;
        isCrossing = false;
        playercontroller.isStopMove = false;
        CameraControl.enabled = true;
        Target.position=-Target.position;

        // �ָ���վ������
        playerAnimator.SetTrigger("Idle");
    }
}



