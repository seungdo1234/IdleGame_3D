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
    private HealthSystem healthSystem;
    private void Awake()
    {
        PlayerStat = new CharacterStat(CharacterData);
        Controller = GetComponent<CharacterController>();
        
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.Stat = PlayerStat;
        
        stateMachine = new PlayerStateMachine(this);
    }
    
    private IEnumerator Start()
    {
        // TODO : EnemyManager Start 순서와 겹쳐 일단 임시로 조치해놓음. 추후에 수정할 예정
        yield return new WaitForSeconds(0.5f);
        stateMachine.ChangeState(stateMachine.ChasingState);
    }
    
    private void Update()
    {
        stateMachine.Update(); 
    }
}
