using System;
using UnityEngine;

[Serializable]
public class PlayerStat : CharacterStat
{
    [field: Header("# Player Data")]
    [field: SerializeField] public float CriticalPercent { get; protected set; }

    [field: SerializeField] public float CriticalDamage { get; protected set; }
    [field: SerializeField] public float CriticalTransitionTime { get; protected set; }

    public PlayerStat(PlayerSO playerSO)
    {
        Initialize(playerSO.BaseHealth, playerSO.BaseMoveSpeed, playerSO.BaseRotationSpeed, playerSO.BaseAttackValue,
            playerSO.BaseAttackRange, playerSO.BaseAttackDelay, playerSO.BaseAttackTransitionTime);

        CriticalPercent = playerSO.BaseCriticalPercent;
        CriticalDamage = playerSO.BaseCriticalDamage;
        CriticalTransitionTime = playerSO.BaseCriticalAttackTransitionTime;
    }

    public void EnforceStat(EnforceType enforceType , float increasePercent)
    {
        switch (enforceType)
        {
            case EnforceType.Attack:
                AttackValue *= increasePercent;
                break;
            case EnforceType.Speed:
                GameManager.Instance.Player.AnimationHandler.IncreaseRunSpeedAnimation(increasePercent);
                MoveSpeed *= increasePercent;
                break;
            case EnforceType.AttackDelay:
                GameManager.Instance.Player.AnimationHandler.IncreaseAttackSpeedAnimation(increasePercent);
                AttackDelay *= increasePercent;
                break;
            case EnforceType.CriticalPercent:
                CriticalPercent *= increasePercent;
                break;
            case EnforceType.CriticalDamage:
                CriticalDamage *= increasePercent;
                break;
        }
    }
}