using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState :  EnemyBaseState ,IState
{
    public EnemyAttackState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public void Enter()
    {
        Debug.Log("Enemy 공격상태 !");
    }

    public void Exit()
    {

    }

    public void Update()
    {
    }
}
