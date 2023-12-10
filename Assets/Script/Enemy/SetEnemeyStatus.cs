using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class SetEnemeyStatus : MonoBehaviour
{
    [ReadOnly]
    public EnumEnemyStatus enemyStatus;
    void SetEnemyStatus(int enemyStatus)
    {
        this.enemyStatus = (EnumEnemyStatus)enemyStatus;
    }

}
