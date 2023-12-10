using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnsetEnemyDes : Conditional
{
    private CharacterAI characterAI;
    public override TaskStatus OnUpdate()
    {
        if (characterAI == null) characterAI = GetComponent<CharacterAI>();
        characterAI.cancelFollowDes();
        return TaskStatus.Success;
    }
}
