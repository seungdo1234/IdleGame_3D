using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationHandler : MonoBehaviour
{
    [field:Header("# Animation Data")]
    [field:SerializeField] public AnimationData AnimationData { get; private set; }
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        AnimationData = new AnimationData();
    }

    public void StartAnimation(int animationHash)
    {
        animator.SetBool(animationHash, true);
    }
    
    public void StopAnimation(int animationHash)
    {
        animator.SetBool(animationHash, false);
    }

    public void SetTriggerAnimation(int animationHash)
    {
        animator.SetTrigger(animationHash);
    }
}
