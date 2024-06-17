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
        Controller.enabled = true;
        HealthSystem.isDead = false;
        stateMachine.ChangeState(stateMachine.ChasingState);
    }
    
    private void DeadEvent()
    {
        Controller.enabled = false;
        AnimationHandler.SetTriggerAnimation(AnimationHandler.AnimationData.DeadParameterHash);
        // 임시로 Invoke 사용 추후 수정할 예정
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
