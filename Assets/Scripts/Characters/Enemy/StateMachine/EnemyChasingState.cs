using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasingState :  EnemyBaseState ,IState
{

    private Transform target;
    private Enemy enemy;
    public EnemyChasingState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
        enemy = base.stateMachine.Enemy;
    }

    public void Enter()
    {
        target = stateMachine.Target.transform;
        enemyAnimation.StartAnimation(enemyAnimation.AnimationData.GroundParameterHash);
        enemyAnimation.StartAnimation(enemyAnimation.AnimationData.IdleParameterHash);
    }

    public void Exit()
    {
        enemyAnimation.StopAnimation(enemyAnimation.AnimationData.GroundParameterHash);
        enemyAnimation.StopAnimation(enemyAnimation.AnimationData.IdleParameterHash);
    }

    public void Update()
    {
        if(stateMachine.Enemy.HealthSystem.isDead) return;
        
        if (ChasingTarget())
        {
            stateMachine.ChangeState(stateMachine.RunState);
        }
    }

    private bool ChasingTarget()
    {
        return Vector3.Distance(enemy.transform.position, target.position) < enemy.EnemyStat.ScanRange;
    }
}
