using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerBaseState, IState
{
    private readonly Player player;
    private readonly float rotationSpeed;
    private bool isRotationComplete;
    private bool isMovementComplete;
    private Vector3 targetDir;
    private Quaternion targetRotation;

    public PlayerRunState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        player = stateMachine.Player;
        rotationSpeed = player.PlayerStat.RotationSpeed;
    }

    public void Enter()
    {
        playerAnimation.StartAnimation(playerAnimation.AnimationData.GroundParameterHash);
        playerAnimation.StartAnimation(playerAnimation.AnimationData.RunParameterHash);

        InitializeTarget();
    }

    public void Exit()
    {
        playerAnimation.StopAnimation(playerAnimation.AnimationData.GroundParameterHash);
        playerAnimation.StopAnimation(playerAnimation.AnimationData.RunParameterHash);
    }

    public void Update()
    {
        if (isRotationComplete && isMovementComplete)
        {
            SwitchStateBasedOnEnemies();
            return;
        }

        if (!isMovementComplete)
        {
            Move();
        }

        Rotate();
    }

    private void InitializeTarget()
    {
        isRotationComplete = false;
        isMovementComplete = false;
        targetDir = GetTargetDirection();
        targetRotation = Quaternion.LookRotation(targetDir);
    }

    private void SwitchStateBasedOnEnemies()
    {
        if (EnemyManager.Instance.SpawnEnemyList.Count > 0)
        {
            stateMachine.ChangeState(stateMachine.AttackState);
        }
        else
        {
            stateMachine.ChangeState(stateMachine.ChasingState);
        }
    }

    private void Move()
    {
        if (Vector3.Distance(player.transform.position, stateMachine.Target.position) < player.PlayerStat.AttackRange)
        {
            isMovementComplete = true;
            return;
        }
        targetDir = GetTargetDirection();
        player.Controller.Move(targetDir * (player.PlayerStat.MoveSpeed * Time.deltaTime));
    }

    private void Rotate()
    {
        if (Quaternion.Angle(player.Model.localRotation, targetRotation) < 0.1f)
        {
            isRotationComplete = true;
            player.Model.localRotation = targetRotation;
        }
        else
        {
            isRotationComplete = false;
            player.Model.localRotation = Quaternion.RotateTowards(player.Model.localRotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }

    private Vector3 GetTargetDirection()
    {
        Vector3 direction = (stateMachine.Target.position - player.transform.position).normalized;
        direction.y = 0f; // Y축을 0으로 설정하여 평면 회전만 고려
        return direction;
    }
}