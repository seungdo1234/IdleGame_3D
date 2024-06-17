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
        Debug.Log("달려");
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
        if (isRotationComplete && isMovementComplete)
        {
            stateMachine.ChangeState(stateMachine.AttackState);
            return;
        }

        if (!isRotationComplete)
        {
            Rotate();
        }

        if (!isMovementComplete)
        {
            Move();
        }
    }
    
    private void Move()
    {
        if (Vector3.Distance(enemy.transform.position, stateMachine.Target.transform.position) < enemy.EnemyStat.AttackRange)
        {
            isMovementComplete = true;
            return;
        }
        enemy.Controller.Move(targetDir * (enemy.EnemyStat.MoveSpeed * Time.deltaTime));
    }

    private void Rotate()
    {
        if (Quaternion.Angle(enemy.Model.localRotation, targetRotation) < 0.1f)
        {
            isRotationComplete = true;
            enemy.Model.localRotation = targetRotation;
            return;
        }
        
        // Debug.Log(Quaternion.RotateTowards(enemy.Model.localRotation, targetRotation, Time.deltaTime * rotationSpeed));
        enemy.Model.localRotation = Quaternion.RotateTowards(enemy.Model.localRotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
    
    private void InitializeTarget()
    {
        rotationSpeed = enemy.EnemyStat.RotationSpeed;
        isRotationComplete = false;
        isMovementComplete = false;
        targetDir = GetTargetDirection();
        targetRotation = Quaternion.LookRotation(targetDir);
        Debug.Log(targetRotation.eulerAngles);
    }
    
    private Vector3 GetTargetDirection()
    {
        Vector3 dir = (stateMachine.Target.transform.position - enemy.transform.position).normalized;
        dir.y = 0f; // Y축을 0으로 설정하여 평면 회전만 고려
        return dir;
    }
}
