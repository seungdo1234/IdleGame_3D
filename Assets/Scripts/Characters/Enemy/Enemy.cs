using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : PoolObject
{

    [field: Header("# Enemy Stats")]
    [field: SerializeField] public EnemyStat EnemyStat { get; private set; }
    
        
    [field: Header("# Character Model")]
    [field:SerializeField] public Transform Model { get; private set; }
    
    public CharacterController Controller { get; private set; }
    public CharacterAnimationHandler AnimationHandler { get; private set; }
    public HealthSystem HealthSystem { get; private set; }
    private EnemyStateMachine stateMachine;
    private void Awake()
    {
        Controller = GetComponent<CharacterController>();
        HealthSystem = GetComponent<HealthSystem>();
        AnimationHandler = GetComponent<CharacterAnimationHandler>();
        
        HealthSystem.OnDead += DeadEvent;
        
        stateMachine = new EnemyStateMachine(this);
    }

    public void Init(EnemySO enemySO)
    {
        EnemyStat = new EnemyStat(enemySO);
        HealthSystem.Stat = EnemyStat;
        stateMachine.ChangeState(stateMachine.ChasingState);
        Controller.enabled = true;
    }
    
    private void DeadEvent()
    {
        Controller.enabled = false;
        AnimationHandler.SetTriggerAnimation(AnimationHandler.AnimationData.DeadParameterHash);
        Invoke("DisableEnemy", 2.5f);
    }

    private void DisableEnemy()
    {
        gameObject.SetActive(false);
    }
    
    private void Update()
    {
        stateMachine.Update(); 
    }
}
