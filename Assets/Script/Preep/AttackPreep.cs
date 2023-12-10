using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks.Unity.UnityLayerMask;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPreep : PreepController
{
    [SerializeField]
    private LayerMask attackedLayer;
    [SerializeField]
    private EnumAttackCharacter character;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Mathf.Pow(2, collision.collider.gameObject.layer) == (int)this.attackedLayer)
        {
            if (attackedLayer == LayerMask.NameToLayer("Player"))
            {
                Debug.Log("½ÇÉ«ËÀÍö");
            }
            else if (collision.collider.gameObject.layer == (int)LayerMask.NameToLayer("Enemy"))
            {
                BehaviorTree bt = collision.collider.gameObject.GetComponent<BehaviorTree>();
                bt.SetVariableValue("IsVertigo", true);
            }
        }
    }
}
