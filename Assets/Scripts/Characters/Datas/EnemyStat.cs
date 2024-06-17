using System;
using UnityEngine;

[Serializable]
public class EnemyStat : CharacterStat
{
    [field:Header("# Enemy Data")]
    [field: SerializeField][field:Range(0f, 100f)] public float ScanRange { get; private set; }
    
    [field:Header("# Reward Data")]
    [field: SerializeField][field:Range(0f, 100f)] public int GoldReward { get; private set; } 
    
    public EnemyStat(EnemySO enemySO)
    {
        Initialize(enemySO.BaseHealth, enemySO.BaseMoveSpeed, enemySO.BaseRotationSpeed, enemySO.BaseAttackValue, enemySO.BaseAttackRange, enemySO.BaseAttackDelay, enemySO.BaseAttackTransitionTime);

        ScanRange = enemySO.BaseScanRange;
        GoldReward = enemySO.BaseGoldReward;
    }
}