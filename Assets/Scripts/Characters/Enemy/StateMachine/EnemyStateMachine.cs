using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : CharacterStateMachine
{
    public Enemy Enemy { get; }
    
    public EnemyChasingState ChasingState { get; }
    public EnemyRunState RunState { get; }
    public EnemyAttackState AttackState { get; }
    
    public CharacterAnimationHandler AnimationHandler { get; private set; }
    
    public HealthSystem Target { get; }
    
    public EnemyStateMachine(Enemy enemy)
    {
        this.Enemy = enemy;
        AnimationHandler = enemy.GetComponent<CharacterAnimationHandler>();
        
        ChasingState = new EnemyChasingState(this);
        RunState = new EnemyRunState(this);
        AttackState = new EnemyAttackState(this);

        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();
        Debug.Log(Target.gameObject.name);
    }

}
