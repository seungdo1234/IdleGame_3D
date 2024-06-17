using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PoolObject
{

    [field: Header("# Enemy Stats")]
    [field: SerializeField] public EnemyStat EnemyStat { get; private set; }
    
        
    [field: Header("# Character Model")]
    [field:SerializeField] public Transform Model { get; private set; }
    
    public CharacterController Controller { get; private set; }
    
    private HealthSystem healthSystem;
    private EnemyStateMachine stateMachine;
    private void Awake()
    {
        Controller = GetComponent<CharacterController>();
        healthSystem = GetComponent<HealthSystem>();
        stateMachine = new EnemyStateMachine(this);
    }

    public void Init(EnemySO enemySO)
    {
        EnemyStat = new EnemyStat(enemySO);
        healthSystem.Stat = EnemyStat;
        stateMachine.ChangeState(stateMachine.ChasingState);
    }
    
    // private void Start()
    // {
    //     stateMachine.ChangeState(stateMachine.ChasingState);
    // }
    //
    
    private void Update()
    {
        stateMachine.Update(); 
    }
}
