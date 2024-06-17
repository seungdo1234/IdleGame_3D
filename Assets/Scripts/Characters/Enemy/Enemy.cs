using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PoolObject
{
    [ Header("# Enemy Data")]
    [SerializeField] private CharacterSO CharacterData;
    
    [field: Header("# Enemy Stats")]
    [field: SerializeField] public CharacterStat EnemyStat { get; private set; }
    
    public CharacterController Controller { get; private set; }
    
    private HealthSystem healthSystem;
    private void Awake()
    {
        EnemyStat = new CharacterStat(CharacterData);
        Controller = GetComponent<CharacterController>();
        
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.Stat = EnemyStat;
        
    }
    
    // private void Start()
    // {
    //     stateMachine.ChangeState(stateMachine.ChasingState);
    // }
    //
    // private void Update()
    // {
    //     stateMachine.Update(); 
    // }
}
