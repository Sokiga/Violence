using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime.Tasks.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPtrol : NavMeshMovement
{
    public SharedBool randomPatrol = false;
    public SharedFloat waypointPauseDuration = 0;
    public SharedInt statusForConditional;
    private SharedGameObjectList waypoints;
    private BehaviorTree behaviorTree;
    private EnemyDesigner enemyDesigner;

    // The current index that we are heading towards within the waypoints array
    private int waypointIndex;
    private float waypointReachedTime;

    public override void OnStart()
    {
        base.OnStart();
        waypoints = GetComponent<EnemyDesigner>().waypoints;
        behaviorTree = GetComponent<BehaviorTree>();
        float distance = Mathf.Infinity;
        float localDistance;
        for (int i = 0; i < waypoints.Value.Count; ++i)
        {
            if ((localDistance = Vector3.Magnitude(transform.position - waypoints.Value[i].transform.position)) < distance)
            {
                distance = localDistance;
                waypointIndex = i;
            }
        }
        waypointReachedTime = -1;
        SetDestination(Target());
    }

    // Patrol around the different waypoints specified in the waypoint array. Always return a task status of running. 
    public override TaskStatus OnUpdate()
    {
        if (statusForConditional.GetValue().ToString() != behaviorTree.GetVariable("AIStatus").GetValue().ToString())
        {
            return TaskStatus.Failure;
        }
        if (waypoints.Value.Count == 0)
        {
            return TaskStatus.Failure;
        }
        if (HasArrived())
        {
            if (waypointReachedTime == -1)
            {
                waypointReachedTime = Time.time;
            }
            // wait the required duration before switching waypoints.
            if (waypointReachedTime + waypointPauseDuration.Value <= Time.time)
            {
                if (randomPatrol.Value)
                {
                    if (waypoints.Value.Count == 1)
                    {
                        waypointIndex = 0;
                    }
                    else
                    {
                        // prevent the same waypoint from being selected
                        var newWaypointIndex = waypointIndex;
                        while (newWaypointIndex == waypointIndex)
                        {
                            newWaypointIndex = Random.Range(0, waypoints.Value.Count);
                        }
                        waypointIndex = newWaypointIndex;
                    }
                }
                else
                {
                    waypointIndex = (waypointIndex + 1) % waypoints.Value.Count;
                }
                SetDestination(Target());
                waypointReachedTime = -1;
            }
        }
        return TaskStatus.Running;
    }

    // Return the current waypoint index position
    private Vector3 Target()
    {
        Vector3 targetPos = Vector3.zero;
        if (waypointIndex >= waypoints.Value.Count)
        {
            targetPos = (Vector3)behaviorTree.GetVariable("waypointPos").GetValue();
        }
        else
        {
            targetPos = waypoints.Value[waypointIndex].transform.position;
        }
        behaviorTree.SetVariableValue("waypointPos", targetPos);
        return targetPos;
    }

    // Reset the public variables
    public override void OnReset()
    {
        base.OnReset();
        randomPatrol = false;
        waypointPauseDuration = 0;
        waypoints = null;
    }

    // Draw a gizmo indicating a patrol 
    public override void OnDrawGizmos()
    {
#if UNITY_EDITOR
        if (waypoints == null || waypoints.Value == null)
        {
            return;
        }
        var oldColor = UnityEditor.Handles.color;
        UnityEditor.Handles.color = Color.yellow;
        for (int i = 0; i < waypoints.Value.Count; ++i)
        {
            if (waypoints.Value[i] != null)
            {
                UnityEditor.Handles.SphereHandleCap(0, waypoints.Value[i].transform.position, waypoints.Value[i].transform.rotation, 1, EventType.Repaint);
            }
        }
        UnityEditor.Handles.color = oldColor;
#endif
    }
}
