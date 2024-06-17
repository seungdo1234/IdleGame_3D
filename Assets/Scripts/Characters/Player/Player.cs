using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [ Header("# Player Data")]
    [SerializeField] private PlayerSO PlayerData;
    
    [field: Header("# Player Stats")]
    [field: SerializeField] public PlayerStat PlayerStat { get; private set; }
    
    [field: Header("# Character Model")]
    [field:SerializeField] public Transform Model { get; private set; }
    
    public CharacterController Controller { get; private set; }
    private PlayerStateMachine stateMachine;
    private HealthSystem healthSystem;
    private void Awake()
    {
        PlayerStat = new PlayerStat(PlayerData);
        Controller = GetComponent<CharacterController>();
        
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.Stat = PlayerStat;
        
        stateMachine = new PlayerStateMachine(this);
    }
    
    private IEnumerator Start()
    {
        // TODO : EnemyManager Start함수 순서보다 빨라서 일단 임시로 조치해놓음. 추후에 수정할 예정
        yield return null;
        GameManager.Instance.Player = this;
        StartNewStage();
    }


    public void StartNewStage()
    {
        SetPlayerPosition();
        stateMachine.ChangeState(stateMachine.ChasingState);
    }

    private void SetPlayerPosition() // 캐릭터 컨트롤러 이슈로 인한 강제이동 ?
    {
        Controller.enabled = false;
        transform.position = GameManager.Instance.StageManager.StartWaypoint.position;
        Controller.enabled = true;
    }
    
    private void Update()
    {
        stateMachine.Update();
    }
}
