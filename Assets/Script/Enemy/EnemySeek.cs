using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime.Tasks.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemySeek : NavMeshMovement
{
    public SharedGameObject target;
    public SharedVector3 targetPosition;
    private BehaviorTree behaviorTree;
    public SharedInt statusForConditional;

    public override void OnStart()
    {
        base.OnStart();
        behaviorTree = GetComponent<BehaviorTree>();
        SetDestination(Target());
    }

    public override TaskStatus OnUpdate()
    {
        if (statusForConditional.GetValue().ToString() != behaviorTree.GetVariable("AIStatus").GetValue().ToString())
        {
            return TaskStatus.Failure;
        }
        if (HasArrived())
        {
            behaviorTree.SetVariableValue("hasArrived", true);
            return TaskStatus.Success;
        }
        SetDestination(Target());
        return TaskStatus.Running;
    }
    private Vector3 Target()
    {
        if (target.Value != null)
        {
            return target.Value.transform.position;
        }
        return targetPosition.Value;
    }

    public override void OnReset()
    {
        base.OnReset();
        target = null;
        targetPosition = Vector3.zero;
    }
}