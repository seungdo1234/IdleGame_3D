using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState ,IState
{

    private float timer;
    public PlayerAttackState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }
    
    public  void Enter()
    {
        playerAnimation.StartAnimation(playerAnimation.AnimationData.AttackParameterHash);
        
        timer = float.MaxValue;
    }

    public  void Exit()
    {
        playerAnimation.StopAnimation(playerAnimation.AnimationData.AttackParameterHash);
    }

    public  void Update()
    {
        if (!stateMachine.Target.gameObject.activeSelf)
        {
            stateMachine.ChangeState(stateMachine.ChasingState);
        }
        
        timer += Time.deltaTime;

        if (timer > stateMachine.Player.PlayerStat.AttackDelay)
        {
            playerAnimation.SetTriggerAnimation(playerAnimation.AnimationData.BaseAttackParameterHash);
            timer = 0f;
        }
    }
    
}
