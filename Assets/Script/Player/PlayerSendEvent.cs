using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSendEvent : Conditional
{
    private List<GameObject> targetGameObject;
    private PlayerController playerController;
    private SharedString eventName;
    public SharedVariable argument1;
    public SharedVariable argument2;
    private List<BehaviorTree> behaviorTrees;
    private BehaviorTree playBT;

    public override void OnStart()
    {
        playerController = GetComponent<PlayerController>();
        targetGameObject = playerController.enemyTarget;
        behaviorTrees = new List<BehaviorTree>();
        playBT = GetComponent<BehaviorTree>();
        for (int i = 0; i < targetGameObject.Count; i++)
        {
            behaviorTrees.Add(targetGameObject[i].GetComponent<BehaviorTree>());
        }
        eventName = "playEvent";
    }

    public override TaskStatus OnUpdate()
    {
        for (int i = 0; i < targetGameObject.Count; ++i)
        {
            behaviorTrees[i].SendEvent<object, object>(eventName.Value, argument1.GetValue(), argument2.GetValue());
        }
        return TaskStatus.Success;
    }

    public override void OnReset()
    {
        targetGameObject = null;
        eventName = "";
    }
}
