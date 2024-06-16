using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerBaseState ,IState
{
    private Player player;
    
    private bool isRotationComplete;
    private bool isMovementComplete;
    
    private Vector3 targetDir;
    private Quaternion targetRotation;
    private float rotationSpeed;
    
    public PlayerRunState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        player = stateMachine.Player;
    }

    public void Enter()
    {
        playerAnimation.StartAnimation(playerAnimation.AnimationData.GroundParameterHash);
        playerAnimation.StartAnimation(playerAnimation.AnimationData.RunParameterHash);

        TargetInitialize();
    }

    public void Exit()
    {
        playerAnimation.StopAnimation(playerAnimation.AnimationData.GroundParameterHash);
        playerAnimation.StopAnimation(playerAnimation.AnimationData.RunParameterHash);
    }

    private void TargetInitialize() // 타겟 초기화
    {
        isRotationComplete = false;
        targetDir = GetTargetDirection();
        targetRotation = Quaternion.LookRotation(targetDir); 
        rotationSpeed = stateMachine.Player.PlayerStat.RotationSpeed;
    }
    
    public void Update()
    {
        if (isRotationComplete && isMovementComplete)
        {
            stateMachine.ChangeState(stateMachine.AttackState);
        }
        
        if(!isRotationComplete)
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
        if (Vector3.Distance(player.transform.position, stateMachine.Target.position) < player.PlayerStat.AttackRange)
        {

            isMovementComplete = true;
            return;
        }
        player.Controller.Move(targetDir * (stateMachine.Player.PlayerStat.MoveSpeed * Time.deltaTime));
    }
    
    private void Rotate() // 회전
    {
        if (Quaternion.Angle(player.Model.localRotation, targetRotation) < 0.1f)
        {
            isRotationComplete = true;
            player.Model.localRotation = targetRotation;
            return;
        }
        
        // 회전
        player.Model.localRotation = Quaternion.RotateTowards(player.Model.localRotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
    
    private Vector3 GetTargetDirection()
    {
        Vector3 dir = (stateMachine.Target.position - player.transform.position).normalized;
        dir.y = 0f; // Y축을 0으로 설정하여 평면 회전만 고려
        return dir;
    }
}
