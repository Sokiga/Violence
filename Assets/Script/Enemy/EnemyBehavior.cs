using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : Conditional
{
    BehaviorTree bt;
    public override void OnAwake()
    {
        base.OnAwake();
        bt = GetComponent<BehaviorTree>();
    }
    public override TaskStatus OnUpdate()
    {

        return TaskStatus.Success;
    }
}
