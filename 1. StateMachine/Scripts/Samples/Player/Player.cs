using UnityEngine;

public class Player : MonoBehaviour, IStateMachine<Player>
{
    private PlayerStateFactory _factory;
    private State<Player> _currentState;

    public State<Player> CurrentState { get { return _currentState; } set { _currentState = value; } }

    private void Awake()
    {
        InitializeStateMachine();
    }

    private void Update()
    {
        _currentState.UpdateStates();
    }

    public void InitializeStateMachine()
    {
        _factory = new PlayerStateFactory(this);
        _currentState = _factory.InitialState;
        _currentState.OnEnter();
    }
}