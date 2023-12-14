using BehaviorDesigner.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnumAttackType
{
    kLongRange,
    kShortRange,
    kNone
}
public enum EnumAttackCharacter
{
    kGiantShadow,
    kBlackShadow,
    kPlayer
}
public enum EnumAttackWay
{
    kBlackBoardBrush,
    kModelGun,
    kIronBars,
    kGSCatch,
    kBSCatch,
    kGSThrow,
    kStone
}
public class AttackWay
{
    public EnumAttackType type;
    public EnumAttackCharacter character;
    public AttackWay(EnumAttackType type, EnumAttackCharacter character)
    {
        this.type = type;
        this.character = character;
    }
}
public class DamageController : MonoBehaviour
{
    [SerializeField]
    private EnumAttackWay attackWayType;
    private AttackWay attackWay;
    private GameObject longRangePreep;
    [SerializeField]
    private PlayerController playerController;
    private Dictionary<EnumAttackWay, AttackWay> attDic = new Dictionary<EnumAttackWay, AttackWay>()
    {
        {   EnumAttackWay.kBlackBoardBrush, new AttackWay(EnumAttackType.kLongRange, EnumAttackCharacter.kPlayer)   },
        {   EnumAttackWay.kModelGun , new AttackWay(EnumAttackType.kLongRange, EnumAttackCharacter.kPlayer)         },
        {   EnumAttackWay.kIronBars , new AttackWay(EnumAttackType.kShortRange, EnumAttackCharacter.kPlayer)        },
        {   EnumAttackWay.kGSCatch , new AttackWay(EnumAttackType.kShortRange, EnumAttackCharacter.kGiantShadow)    },
        {   EnumAttackWay.kBSCatch , new AttackWay(EnumAttackType.kShortRange, EnumAttackCharacter.kBlackShadow)    },
        {   EnumAttackWay.kGSThrow , new AttackWay(EnumAttackType.kLongRange, EnumAttackCharacter.kGiantShadow)     },
        {   EnumAttackWay.kStone, new AttackWay(EnumAttackType.kNone,EnumAttackCharacter.kPlayer)                   }
    };
    private void Start()
    {
        SetAttackStatus(attackWayType);
    }
    private void Update()
    {
    }
    public void LongRangeAttack()
    {
        if (attackWay.character == EnumAttackCharacter.kPlayer)
        {
            playerController.preepPrefabs = longRangePreep;
            if (attackWayType == EnumAttackWay.kModelGun)
            {
                playerController.isShowCircle = false;
            }
            else
            {
                playerController.isShowCircle = true;
            }
        }
        else
        {

        }
    }
    public void ShortRangeAttack()
    {

    }
    private void LoadPreep()
    {
        switch (attackWayType)
        {
            case EnumAttackWay.kBlackBoardBrush:
                longRangePreep = Resources.Load<GameObject>("Prefabs/BackBoardBush");
                break;
            case EnumAttackWay.kModelGun:
                longRangePreep = Resources.Load<GameObject>("Prefabs/Bullet");
                break;
            case EnumAttackWay.kGSThrow:
                longRangePreep = Resources.Load<GameObject>("Prefabs/Obstacles");
                break;
            case EnumAttackWay.kStone:
                longRangePreep = Resources.Load<GameObject>("Prefabs/Stone");
                break;
            default:
                longRangePreep = null;
                break;
        }
    }
    public void SetAttackStatus(EnumAttackWay attackWayType)
    {
        this.attackWayType = attackWayType;
        attackWay = attDic[attackWayType];
        LoadPreep();
        LongRangeAttack();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (attackWay.character == EnumAttackCharacter.kPlayer)
            {
                collision.gameObject.GetComponent<BehaviorTree>().SetVariableValue(
                    "IsVertigo", true);
            }
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (attackWay.character != EnumAttackCharacter.kPlayer)
            {
                Debug.Log("½ÇÉ«ËÀÍö");
            }
        }
    }
}
