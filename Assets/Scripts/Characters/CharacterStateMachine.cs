public interface IState
{
    public void Enter(); // 진입
    public void Exit(); // 나가기
    public void Update(); // 업데이트 => 상태 업데이트
}

public abstract class CharacterStateMachine
{
    protected IState currentState;

    public void ChangeState(IState state)
    {
        currentState?. Exit();
        currentState = state;
        currentState?.Enter();
    }

    public void Update()
    {
        currentState?.Update();
    }
    
}