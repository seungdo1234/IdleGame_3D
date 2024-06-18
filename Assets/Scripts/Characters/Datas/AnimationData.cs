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
    [SerializeField] private string idleParameterName = "Idle";
    [SerializeField] private string deadParameterName = "Dead";
    
    [SerializeField] private string attackParameterName = "@Attack";
    [SerializeField] private string baseAttackParameterName = "BaseAttack";
    [SerializeField] private string criticalAttackParameterName = "CriticalAttack";
    
    [SerializeField] private string RunSpeedParameterName = "RunSpeed";
    [SerializeField] private string criticalAttackSpeedParameterName = "CriticalAttackSpeed";
    [SerializeField] private string baseAttackSpeedParameterName = "BaseAttackSpeed";
    
    public int GroundParameterHash { get; private set; }
    public int RunParameterHash { get; private set; }
    public int IdleParameterHash { get; private set; }
    public int DeadParameterHash { get; private set; }
    
    public int AttackParameterHash { get; private set; }
    public int BaseAttackParameterHash { get; private set; }
    public int CriticalAttackParameterHash { get; private set; }
    
    public int RunSpeedParameterHash { get; private set; }
    public int CriticalAttackSpeedParameterHash { get; private set; }
    public int BaseAttackSpeedParameterHash { get; private set; }

    public AnimationData()
    {
        GroundParameterHash = Animator.StringToHash(groundParameterName);
        RunParameterHash = Animator.StringToHash(runParameterName);
        IdleParameterHash = Animator.StringToHash(idleParameterName);
        DeadParameterHash = Animator.StringToHash(deadParameterName);
        
        AttackParameterHash = Animator.StringToHash(attackParameterName);
        CriticalAttackParameterHash = Animator.StringToHash(criticalAttackParameterName);
        BaseAttackParameterHash = Animator.StringToHash(baseAttackParameterName);
        
        RunSpeedParameterHash = Animator.StringToHash(RunSpeedParameterName);
        BaseAttackSpeedParameterHash = Animator.StringToHash(criticalAttackSpeedParameterName);
        CriticalAttackSpeedParameterHash = Animator.StringToHash(baseAttackSpeedParameterName);
    }
}
