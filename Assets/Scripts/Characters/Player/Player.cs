using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [ Header("# Player Data")]
    [SerializeField] private CharacterSO CharacterData;
    
    [field: Header("# Player Stats")]
    [field: SerializeField] public CharacterStat PlayerStat { get; private set; }
    
    [field: Header("# Character Model")]
    [field:SerializeField] public Transform Model { get; private set; }
    
    public CharacterController Controller { get; private set; }
    private PlayerStateMachine stateMachine;
    
    private void Awake()
    {
        PlayerStat = new CharacterStat(CharacterData);
        Controller = GetComponent<CharacterController>();
        
        stateMachine = new PlayerStateMachine(this);
    }
    
    private void Start()
    {
        stateMachine.ChangeState(stateMachine.ChasingState);
    }
    
    private void Update()
    {
        stateMachine.Update(); 
    }
}
