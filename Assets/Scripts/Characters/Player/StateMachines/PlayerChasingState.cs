using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChasingState : PlayerBaseState, IState
{
    private EnemyManager em;
    private GameManager gm;
    
    public PlayerChasingState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        em = EnemyManager.Instance;
        gm = GameManager.Instance;
    }

    public void Enter()
    {
        stateMachine.Target = ChasingTarget();
        
        stateMachine.ChangeState(stateMachine.RunState);
        
    }

    public void Exit()
    {
        
    }

    public void Update()
    {
        
    }

    private Transform ChasingTarget()
    {
        if (em.enemys == null || em.enemys.Count == 0)
        {
            return gm.EndWaypoint;
        }
        
        Transform minDistanceTarget = null;
        float minDistanceValue= float.MaxValue;
        
        foreach (Transform target in em.enemys)
        {
            if(!target.gameObject.activeSelf) continue;
            
            float distanceValue = Vector3.Distance(stateMachine.Player.transform.position, target.position);
            if (distanceValue < minDistanceValue)
            {
                minDistanceValue = distanceValue;
                minDistanceTarget = target;
            }
        }

        return minDistanceTarget;
    }

    
}
   
