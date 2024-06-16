using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: Header("# Player Data")]
    [field: SerializeField] public CharacterSO CharacterData { get; private set; }
    
    [field: Header("# Player Stats")]
    [field: SerializeField] public CharacterStat CharacterStat { get; private set; }
    
    
    public CharacterController Controller { get; private set; }
    private PlayerStateMachine stateMachine;
    
    private void Awake()
    {
        CharacterStat = new CharacterStat(CharacterData);
        Controller = GetComponent<CharacterController>();
        
        stateMachine = new PlayerStateMachine(this);
    }
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        stateMachine.ChangeState(stateMachine.ChasingState);
    }
    
    private void Update()
    {
        stateMachine.Update(); 
    }
}
