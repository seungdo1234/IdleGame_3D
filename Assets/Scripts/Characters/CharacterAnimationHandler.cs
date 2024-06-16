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
}
