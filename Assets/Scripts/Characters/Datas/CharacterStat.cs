using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterStat 
{
    [field:Header("# Base Data")]
    [field: SerializeField]public float MaxHealth { get;  set; }
    [field: SerializeField]public float CurHealth { get;  set; }
    
    [field:Header("# Move Data")]
    [field: SerializeField]public float MoveSpeed { get; protected set; } 
    [field: SerializeField] public float RotationSpeed { get; protected set; }  // 로테이션 속도
    
    [field:Header("# Attack Data")]
    [field: SerializeField] public float AttackValue { get; protected set; }
    [field: SerializeField] public float AttackRange { get; protected set; }
    [field: SerializeField] public float AttackDelay { get; protected set; }
    [field: SerializeField] public float AttackTransitionTime { get; protected set; }
    
    // 공통 생성자를 통해 초기화 작업을 공통화
    protected void Initialize(float maxHealth, float moveSpeed, float rotationSpeed, float attackValue, float attackRange, float attackDelay, float attackTransitionTime)
    {
        MaxHealth = maxHealth;
        CurHealth = MaxHealth;

        MoveSpeed = moveSpeed;
        RotationSpeed = rotationSpeed;

        AttackValue = attackValue;
        AttackRange = attackRange;
        AttackDelay = attackDelay;
        AttackTransitionTime = attackTransitionTime;
    }
}