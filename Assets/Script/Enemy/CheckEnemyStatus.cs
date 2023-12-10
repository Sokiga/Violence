using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemyStatus : Conditional
{
    public SharedInt statusForConditional = 0;
    private BehaviorTree behaviorTree;
    public override void OnStart()
    {
        base.OnStart();
        behaviorTree = GetComponent<BehaviorTree>();
    }
    public override TaskStatus OnUpdate()
    {
        if (statusForConditional.GetValue().ToString() == behaviorTree.GetVariable("AIStatus").GetValue().ToString())
        {
            return TaskStatus.Success;
        }
        else
        {
            return TaskStatus.Failure;
        }
    }
}
