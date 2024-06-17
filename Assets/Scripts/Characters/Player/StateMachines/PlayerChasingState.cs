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
        if (em.SpawnEnemyList == null || em.SpawnEnemyList.Count == 0)
        {
            return gm.StageManager.GetEndWaypoint;
        }
        
        Transform minDistanceTarget = null;
        float minDistanceValue= float.MaxValue;
        
        foreach (var target in em.SpawnEnemyList)
        {
            if(!target.gameObject.activeSelf) continue;
            
            float distanceValue = Vector3.Distance(stateMachine.Player.transform.position, target.transform.position);
            if (distanceValue < minDistanceValue)
            {
                minDistanceValue = distanceValue;
                minDistanceTarget = target.transform;
            }
        }

        return minDistanceTarget;
    }

    
}
   
