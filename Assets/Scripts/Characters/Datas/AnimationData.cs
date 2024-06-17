using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AnimationData 
{
    // @는 레이어로 들어가는 파라미터 값을 나타냄
    [SerializeField] private string groundParameterName = "@Ground";
    [SerializeField] private string runParameterName = "Run";
    [SerializeField] private string idleParameterName = "Run";
    
    [SerializeField] private string attackParameterName = "@Attack";
    [SerializeField] private string baseAttackParameterName = "BaseAttack";
    [SerializeField] private string criticalAttackParameterName = "CriticalAttack";
    
    public int GroundParameterHash { get; private set; }
    public int RunParameterHash { get; private set; }
    public int IdleParameterHash { get; private set; }
    
    public int AttackParameterHash { get; private set; }
    public int BaseAttackParameterHash { get; private set; }
    public int CriticalAttackParameterHash { get; private set; }

    public AnimationData()
    {
        GroundParameterHash = Animator.StringToHash(groundParameterName);
        RunParameterHash = Animator.StringToHash(runParameterName);
        IdleParameterHash = Animator.StringToHash(idleParameterName);
        
        AttackParameterHash = Animator.StringToHash(attackParameterName);
        CriticalAttackParameterHash = Animator.StringToHash(criticalAttackParameterName);
        BaseAttackParameterHash = Animator.StringToHash(baseAttackParameterName);
    }
}
