public abstract class State<T> where T : class
{
    private bool _isRootState = false;
    private IStateMachine<T> _context;
    private IStateFactory<T> _factory;
    private State<T> _currentSubState;
    private State<T> _currentSuperState;

    protected bool IsRootState { set { _isRootState = value; } }

    public State(IStateMachine<T> context, IStateFactory<T> factory)
    {
        _context = context;
        _factory = factory;
    }

    public abstract void OnEnter();
    public abstract void OnUpdate();
    public abstract void OnExit();

    public abstract void CheckSwitchStates();
    public virtual void InitializeSubState() { }

    public void UpdateStates()
    {
        OnUpdate();

        _currentSubState?.OnUpdate();
    }

    public void SwitchState(State<T> newState)
    {
        OnExit();
        newState.OnEnter();

        if (_isRootState)
            _context.CurrentState = newState;
        else
            _currentSuperState.SetSubState(newState);
    }

    protected void SetSubState(State<T> subState)
    {
        _currentSubState = subState;
        subState.SetSuperState(this);
    }

    protected void SetSuperState(State<T> supState)
    {
        _currentSuperState = supState;
    }
}