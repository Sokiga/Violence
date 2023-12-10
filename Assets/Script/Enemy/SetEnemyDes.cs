using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEnemyDes : Conditional
{
    private CharacterAI characterAI = null;
    public override TaskStatus OnUpdate()
    {
        if (characterAI == null) characterAI = GetComponent<CharacterAI>();
        characterAI.isFollowDes(true);
        return TaskStatus.Success;
    }
}
