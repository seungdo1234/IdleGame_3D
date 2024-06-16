using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Character/Player")]
public class CharacterSO : ScriptableObject
{
    [field:Header("# BaseData")]
    [field: SerializeField][field:Range(1f, 150f)] public float BaseHealth { get; private set; } = 100f;
    
    [field:Header("# MoveData")]
    [field: SerializeField][field:Range(1f, 25f)] public float BaseMoveSpeed { get; private set; } = 5f;
    [field: SerializeField][field: Range(1f, 25f)] public float BaseRotationSpeed { get; private set; } = 1f; // 로테이션 속도
    
    [field:Header("# AttackData")]
    [field: SerializeField][field:Range(1f, 20f)] public float BaseAttackValue { get; private set; } = 15f;
    [field: SerializeField][field:Range(0f, 3f)] public float BaseAttackDelay { get; private set; } = 1.5f;
    [field: SerializeField][field:Range(0f, 100f)] public float BaseCriticalPercent { get; private set; } = 10f;
    [field: SerializeField][field:Range(1f, 5f)] public float BaseCriticalDamage { get; private set; } = 1.5f;
}
