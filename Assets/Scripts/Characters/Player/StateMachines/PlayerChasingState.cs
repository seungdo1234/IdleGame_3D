using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChasingState : PlayerBaseState, IState
{
    public PlayerChasingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public void Enter()
    {
        playerAnimation.StartAnimation(playerAnimation.AnimationData.GroundParameterHash);
    }

    public void Exit()
    {
        playerAnimation.StopAnimation(playerAnimation.AnimationData.GroundParameterHash);
    }

    public void Update()
    {
      
    }
    
    
}
   
