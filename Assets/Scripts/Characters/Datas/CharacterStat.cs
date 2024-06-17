using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterStat 
{
    [field:Header("# BaseData")]
    [field: SerializeField]public float MaxHealth { get;  set; }
    [field: SerializeField]public float CurHealth { get;  set; }
    
    [field:Header("# MoveData")]
    [field: SerializeField]public float MoveSpeed { get; private set; } 
    [field: SerializeField] public float RotationSpeed { get; private set; }  // 로테이션 속도
    
    [field:Header("# AttackData")]
    [field: SerializeField] public float AttackValue { get; private set; }
    [field: SerializeField] public float AttackRange { get; private set; }
    [field: SerializeField] public float AttackDelay { get; private set; }
    [field: SerializeField] public float CriticalPercent { get; private set; } 
    [field: SerializeField] public float CriticalDamage { get; private set; }
    [field: SerializeField] public float CriticalTransitionTime { get; private set; }
    [field: SerializeField] public float AttackTransitionTime { get; private set; }


    public CharacterStat(CharacterSO characterSo)
    {
        MaxHealth = characterSo.BaseHealth;
        CurHealth = MaxHealth;

        MoveSpeed = characterSo.BaseMoveSpeed;
        RotationSpeed = characterSo.BaseRotationSpeed;

        AttackValue = characterSo.BaseAttackValue;
        AttackRange = characterSo.BaseAttackRange;
        AttackDelay = characterSo.BaseAttackDelay;
        CriticalPercent = characterSo.BaseCriticalPercent;
        CriticalDamage = characterSo.BaseCriticalDamage;
        AttackTransitionTime = characterSo.BaseAttackTransitionTime;
        CriticalTransitionTime = characterSo.BaseCriticalAttackTransitionTime;
    }
} 
