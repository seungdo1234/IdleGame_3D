using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunState :   EnemyBaseState ,IState
{
    private readonly Enemy enemy;
    private float rotationSpeed;
    private bool isRotationComplete;
    private bool isMovementComplete;
    private Vector3 targetDir;
    private Quaternion targetRotation;
    
    public EnemyRunState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
        enemy = stateMachine.Enemy;
    }

    public void Enter()
    {
        enemyAnimation.StartAnimation(enemyAnimation.AnimationData.GroundParameterHash);
        enemyAnimation.StartAnimation(enemyAnimation.AnimationData.RunParameterHash);
        
        InitializeTarget();
    }

    public void Exit()
    {
        enemyAnimation.StopAnimation(enemyAnimation.AnimationData.GroundParameterHash);
        enemyAnimation.StopAnimation(enemyAnimation.AnimationData.RunParameterHash);
    }
    public void Update()
    {
        if(stateMachine.Enemy.HealthSystem.isDead) return;
        
        if (isRotationComplete && isMovementComplete)
        {
            stateMachine.ChangeState(stateMachine.AttackState);
            return;
        }

        
        if (!isMovementComplete)
        {
            Move();
        }
        
        Rotate();
    }
    
    private void Move()
    {
        if (Vector3.Distance(enemy.transform.position, stateMachine.Target.transform.position) < enemy.EnemyStat.AttackRange)
        {
            isMovementComplete = true;
            return;
        }
        targetDir = GetTargetDirection();
        enemy.Controller.Move(targetDir * (enemy.EnemyStat.MoveSpeed * Time.deltaTime));
    }

    private void Rotate() // 타겟을 향해 회전
    {
        targetRotation = Quaternion.LookRotation(targetDir);
        
        if (Quaternion.Angle(enemy.Model.localRotation, targetRotation) < 0.1f)
        {
            isRotationComplete = true;
            enemy.Model.localRotation = targetRotation;
        }
        else // 아직 회전이 덜됐을 때
        {
            isRotationComplete = false;
            enemy.Model.localRotation = Quaternion.RotateTowards(enemy.Model.localRotation, targetRotation, Time.deltaTime * rotationSpeed);   
        }
    }
    
    private void InitializeTarget()
    {
        rotationSpeed = enemy.EnemyStat.RotationSpeed;
        isRotationComplete = false;
        isMovementComplete = false;
    }
    
    private Vector3 GetTargetDirection()
    {
        Vector3 dir = (stateMachine.Target.transform.position - enemy.transform.position).normalized;
        dir.y = 0f; // Y축을 0으로 설정하여 평면 회전만 고려
        return dir;
    }
}
