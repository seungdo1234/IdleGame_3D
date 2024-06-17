using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterSO : ScriptableObject
{
    [field:Header("# Base Data")]
    [field: SerializeField][field:Range(1f, 150f)] public float BaseHealth { get; private set; } = 100f;
    
    [field:Header("# Move Data")]
    [field: SerializeField][field:Range(1f, 25f)] public float BaseMoveSpeed { get; private set; } = 5f;
    [field: SerializeField][field: Range(1f, 1000f)] public float BaseRotationSpeed { get; private set; } = 100f; // 로테이션 속도
    
    [field:Header("# Attack Data")]
    [field: SerializeField][field:Range(1f, 20f)] public float BaseAttackValue { get; private set; } = 15f;
    [field: SerializeField][field:Range(0f, 10f)] public float BaseAttackRange { get; private set; } = 5f;
    [field: SerializeField][field:Range(0f, 10f)] public float BaseAttackDelay { get; private set; } = 1.5f;
    [field: SerializeField][field:Range(0f, 1f)] public float BaseAttackTransitionTime { get; private set; } = 0.4f;
}