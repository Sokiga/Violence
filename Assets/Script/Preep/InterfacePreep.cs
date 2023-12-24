using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfacePreep : PreepController
{
    protected PlayerController playerController;
    protected override void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        base.Start();
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
        PreepSetEvent();
        base.OnCntGreaterStop();
    }
}
