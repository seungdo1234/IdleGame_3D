using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : CharacterStateMachine
{
    public Player Player { get; }
    
    public PlayerChasingState ChasingState { get; }
    public PlayerRunState RunState { get; }
    public PlayerAttackState AttackState { get; }
    
    public CharacterAnimationHandler AnimationHandler { get; private set; }
    
    public Transform Target { get; set; }
    
    public PlayerStateMachine(Player player)
    {
        this.Player = player;
        AnimationHandler = player.GetComponent<CharacterAnimationHandler>();
        
        ChasingState = new PlayerChasingState(this);
        RunState = new PlayerRunState(this);
        AttackState = new PlayerAttackState(this);
        
    }
    
    
}
