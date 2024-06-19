public class CharacterStateMachine
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