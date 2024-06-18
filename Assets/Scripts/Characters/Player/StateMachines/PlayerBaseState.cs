using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState 
{
    protected PlayerStateMachine stateMachine;
    protected CharacterAnimationHandler playerAnimation;

    protected PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
        playerAnimation = stateMachine.Player.AnimationHandler;
    }

}
