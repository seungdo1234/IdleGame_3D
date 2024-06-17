using System;
using UnityEngine;

[Serializable]
public class PlayerStat : CharacterStat
{
    [field:Header("# Player Data")]
    [field: SerializeField] public float CriticalPercent { get; protected set; } 
    [field: SerializeField] public float CriticalDamage { get; protected set; }
    [field: SerializeField] public float CriticalTransitionTime { get; protected set; }
    
    public PlayerStat(PlayerSO playerSO)
    {
        Initialize(playerSO.BaseHealth, playerSO.BaseMoveSpeed, playerSO.BaseRotationSpeed, playerSO.BaseAttackValue, playerSO.BaseAttackRange, playerSO.BaseAttackDelay, playerSO.BaseAttackTransitionTime);

        CriticalPercent = playerSO.BaseCriticalPercent;
        CriticalDamage = playerSO.BaseCriticalDamage;
        CriticalTransitionTime = playerSO.BaseCriticalAttackTransitionTime;
    }
}