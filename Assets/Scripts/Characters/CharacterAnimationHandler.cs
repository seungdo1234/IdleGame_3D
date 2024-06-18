using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationHandler : MonoBehaviour
{
    [field:Header("# Animation Data")]
    [field:SerializeField] public AnimationData AnimationData { get; private set; }
    public Animator Animator { get; private set; }

    private void Awake()
    {
        Animator = GetComponentInChildren<Animator>();
        AnimationData = new AnimationData();
    }

    public void StartAnimation(int animationHash)
    {
        Animator.SetBool(animationHash, true);
    }
    
    public void StopAnimation(int animationHash)
    {
        Animator.SetBool(animationHash, false);
    }

    public void SetTriggerAnimation(int animationHash)
    {
        Animator.SetTrigger(animationHash);
    }
    
    public void IncreaseAttackSpeedAnimation(float increaseValue) // 공격속도 증가에 맞게 애니메이션 속도도 증가시켜줌
    {
        Animator.SetFloat(AnimationData.BaseAttackSpeedParameterHash ,Animator.GetFloat(AnimationData.BaseAttackSpeedParameterHash) * (increaseValue + 0.002f));
        Animator.SetFloat(AnimationData.CriticalAttackSpeedParameterHash ,Animator.GetFloat(AnimationData.CriticalAttackSpeedParameterHash) *  (increaseValue + 0.002f) );
    }
    
    public void IncreaseRunSpeedAnimation(float increaseValue) // 공격속도 증가에 맞게 애니메이션 속도도 증가시켜줌
    {
        Animator.SetFloat(AnimationData.RunSpeedParameterHash ,Animator.GetFloat(AnimationData.RunSpeedParameterHash) * increaseValue);
     }
}
