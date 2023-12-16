using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfacePreep : PreepController
{
    protected PlayerController playerController;
    private Animator animator;
    public float ratioSpeed;
    protected override void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        base.Start();
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, Random.Range(0, 180));
        animator = GetComponent<Animator>();
    }
    private void PreepUnSetEvent()
    {
        playerController.isSendEvent = true;
        playerController.soundType = SoundType.kNone;
        playerController.UnSetEvent();
    }
    private void PreepSetEvent()
    {
        playerController.isSendEvent = false;
        playerController.SendEventToEnemy(soundType, transform.position);
    }
    protected override void OnCntGreaterDestrory()
    {
        PreepUnSetEvent();
        base.OnCntGreaterDestrory();
    }
    protected override void OnCntGreaterStop()
    {
        animator.SetBool("is_noise", true);
        PreepSetEvent();
        base.OnCntGreaterStop();
    }
    protected override void Update()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + ratioSpeed * Time.deltaTime);
        base.Update();
    }
}
