using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState ,IState
{
    private float damage;
    private float transitionTime;
    private bool isAttack;
    private float timer;

    private HealthSystem targetHealthSystem;
    public PlayerAttackState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }
    
    public  void Enter()
    {
        playerAnimation.StartAnimation(playerAnimation.AnimationData.AttackParameterHash);

        isAttack = false;
        timer = float.MaxValue;
        damage = 0f;
        transitionTime = 0f;
        
        if (!stateMachine.Target.TryGetComponent(out targetHealthSystem))
        {
            Debug.Log("목표물 설정 Error");
            stateMachine.ChangeState(stateMachine.ChasingState);
        }
        
    }

    public  void Exit()
    {
        playerAnimation.StopAnimation(playerAnimation.AnimationData.AttackParameterHash);
        targetHealthSystem = null;
    }

    public  void Update()
    {
        AnimatorStateInfo curAnimationInfo = playerAnimation.Animator.GetCurrentAnimatorStateInfo(0);
        if (!stateMachine.Target.gameObject.activeSelf && curAnimationInfo.normalizedTime >= 0.8f )
        {
            stateMachine.ChangeState(stateMachine.ChasingState);
        }

        AttackTarget(curAnimationInfo);
        AttackEvent();
    }

    private void AttackEvent()
    {
        timer += Time.deltaTime;

        if (timer > stateMachine.Player.PlayerStat.AttackDelay)
        {
            isAttack = true;
            
            damage = stateMachine.Player.PlayerStat.AttackValue;
            
            if (RandomEvent.RandomBoolResult(stateMachine.Player.PlayerStat.CriticalPercent))
            {
                Debug.Log("치명타 !");
                transitionTime = stateMachine.Player.PlayerStat.CriticalTransitionTime;
                damage *= stateMachine.Player.PlayerStat.CriticalDamage;
                playerAnimation.SetTriggerAnimation(playerAnimation.AnimationData.CriticalAttackParameterHash);
            }
            else
            {
                transitionTime = stateMachine.Player.PlayerStat.AttackTransitionTime;
                playerAnimation.SetTriggerAnimation(playerAnimation.AnimationData.BaseAttackParameterHash);
            }
            
            timer = 0f;
        }
    }
    private void AttackTarget(AnimatorStateInfo curAnimationInfo)
    {
        if (isAttack && curAnimationInfo.IsTag("Attack")&& curAnimationInfo.normalizedTime > transitionTime)
        {
            isAttack = false;
            targetHealthSystem.HealthEvent(-damage);
            
            Debug.Log("공격");
        }
    }
}
