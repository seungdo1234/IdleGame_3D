using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseState 
{
    protected EnemyStateMachine stateMachine;
    protected CharacterAnimationHandler enemyAnimation;

    protected EnemyBaseState(EnemyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
        enemyAnimation = stateMachine.AnimationHandler;
    }
}
