using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterStat 
{
    [field:Header("# BaseData")]
    [field: SerializeField]public float MaxHealth { get; private set; }
    [field: SerializeField]public float CurHealth { get; private set; }
    
    [field:Header("# MoveData")]
    [field: SerializeField]public float MoveSpeed { get; private set; } 
    [field: SerializeField] public float RotationSpeed { get; private set; }  // 로테이션 속도
    
    [field:Header("# AttackData")]
    [field: SerializeField] public float AttackValue { get; private set; }
    [field: SerializeField] public float AttackDelay { get; private set; }
    [field: SerializeField] public float CriticalPercent { get; private set; } 
    [field: SerializeField] public float CriticalDamage { get; private set; }


    public CharacterStat(CharacterSO characterSo)
    {
        MaxHealth = characterSo.BaseHealth;
        CurHealth = MaxHealth;

        MoveSpeed = characterSo.BaseMoveSpeed;
        RotationSpeed = characterSo.BaseRotationSpeed;

        AttackValue = characterSo.BaseAttackValue;
        AttackDelay = characterSo.BaseAttackDelay;
        CriticalPercent = characterSo.BaseCriticalPercent;
        CriticalDamage = characterSo.BaseCriticalDamage;
    }
} 
