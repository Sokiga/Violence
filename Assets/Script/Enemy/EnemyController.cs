using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public enum EnumEnemyStatus
{
    kPatrol,    //Ñ²Âß
    kCruise,    //Ñ²º½
    kVertigo,   //Ñ£ÔÎ
    kAttack,    //¹¥»÷
    kPerceive   //¸ÐÖª
};
public class EnemyController : Conditional
{
    public SharedString eventName = "";
    public SharedVariable storedValue1;
    public SharedVariable storedValue2;
    private bool eventReceived = false;
    private bool registered = false;
    BehaviorTree behaviorTree;

    public override void OnStart()
    {
        eventName = "playEvent";
        // Let the behavior tree know that we are interested in receiving the event specified
        if (!registered)
        {
            behaviorTree = GetComponent<BehaviorTree>();
            Owner.RegisterEvent<object, object>(eventName.Value, ReceivedEvent);
            registered = true;
        }
    }
    public override void OnEnd()
    {
        if (eventReceived)
        {
            Owner.UnregisterEvent<object, object>(eventName.Value, ReceivedEvent);
            registered = false;
        }
        eventReceived = false;
    }


    private void ReceivedEvent(object arg1, object arg2)
    {
        if (storedValue1 != null && !storedValue1.IsNone)
        {
            storedValue1.SetValue(arg1);
        }

        if (storedValue2 != null && !storedValue2.IsNone)
        {
            storedValue2.SetValue(arg2);
        }
        behaviorTree.SetVariable("targetPos", storedValue1);
        behaviorTree.SetVariable("targetRange", storedValue2);
        if((bool)behaviorTree.GetVariable("IsVertigo").GetValue()==true)
        {
            behaviorTree.SetVariableValue("AIStatus", EnumEnemyStatus.kVertigo);
        }
        else if ((transform.position - (Vector3)arg1).magnitude < (float)arg2)
        {
            behaviorTree.SetVariableValue("AIStatus", EnumEnemyStatus.kCruise);
        }
        else
        {
            behaviorTree.SetVariableValue("AIStatus", EnumEnemyStatus.kPatrol);
        }
    }
    public override void OnBehaviorComplete()
    {
        Owner.UnregisterEvent<object, object>(eventName.Value, ReceivedEvent);
        eventReceived = false;
        registered = false;
    }
}