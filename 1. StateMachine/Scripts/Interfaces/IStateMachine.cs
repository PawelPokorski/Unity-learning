public interface IStateMachine<T> where T : class
{
    State<T> CurrentState { get; set; }
    void InitializeStateMachine();
}