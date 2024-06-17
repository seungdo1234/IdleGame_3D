using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState :  EnemyBaseState ,IState
{
    private float damage;
    private float transitionTime;
    private bool isAttack;
    private float timer;
    public EnemyAttackState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public void Enter()
    {
        Debug.Log("Enemy 공격상태 !");
        enemyAnimation.StartAnimation(enemyAnimation.AnimationData.AttackParameterHash);
        
        isAttack = false;
        timer = float.MaxValue;
        damage = 0f;
        transitionTime = 0f;
    }

    public void Exit()
    {
        enemyAnimation.StopAnimation(enemyAnimation.AnimationData.AttackParameterHash);
    }

    public void Update()
    {
        if(stateMachine.Enemy.HealthSystem.isDead) return;
        
        AnimatorStateInfo curAnimationInfo = enemyAnimation.Animator.GetCurrentAnimatorStateInfo(0);
        if (stateMachine.Target.isDead && curAnimationInfo.normalizedTime >= 0.8f )
        {
            stateMachine.ChangeState(stateMachine.ChasingState);
        }

        AttackTarget(curAnimationInfo);
        AttackEvent();
    }
    
    private void AttackEvent()
    {
        timer += Time.deltaTime;

        if (timer > stateMachine.Enemy.EnemyStat.AttackDelay)
        {
            isAttack = true;
            
            damage = stateMachine.Enemy.EnemyStat.AttackValue;
            transitionTime = stateMachine.Enemy.EnemyStat.AttackTransitionTime;
            enemyAnimation.SetTriggerAnimation(enemyAnimation.AnimationData.BaseAttackParameterHash);
            
            timer = 0f;
        }
    }
    private void AttackTarget(AnimatorStateInfo curAnimationInfo)
    {
        if (isAttack && curAnimationInfo.IsTag("Attack")&& curAnimationInfo.normalizedTime > transitionTime)
        {
            isAttack = false;
            // stateMachine.Target.HealthEvent(-damage);
        }
    }
}
