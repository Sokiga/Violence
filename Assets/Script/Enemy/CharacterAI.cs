using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAI : MonoBehaviour
{
    public NavMeshAgent meshAgent;
    public Transform targetTrans;
    public Transform patrolTrans;
    public Vector3 warpPosition = new Vector3(4, 0, -3);
    private bool isFollow = false;
    private void Start()
    {
        meshAgent.updateRotation = false;
        meshAgent.updateUpAxis = false;
        TestNavigation();
    }
    private void Update()
    {
        if(isFollow)
        {
            NavSetDestination(targetTrans.position);
        }
    }
    public bool TestNavigation()
    {
        if (meshAgent.isOnNavMesh)
        {
            NavMeshHit navigationHit;
            if (NavMesh.SamplePosition(targetTrans.position, out navigationHit, 15, meshAgent.areaMask))
                return meshAgent.SetDestination(navigationHit.position);
            return false;
        }
        else
        {
            return meshAgent.Warp(new Vector3(transform.position.x, transform.position.y, warpPosition.z));
        }
    }
    private void NavSetDestination(Vector3 pos)
    {
        float agentOffset = 0.0001f;
        Vector3 agentPos = (Vector3)(agentOffset * Random.insideUnitCircle) + pos;
        meshAgent.SetDestination(agentPos);
    }
    public void isFollowDes(bool isFollow)
    {
        this.isFollow = isFollow;
    }
    public void cancelFollowDes()
    {
        isFollowDes(false);
        NavSetDestination(patrolTrans.position);
    }
}
