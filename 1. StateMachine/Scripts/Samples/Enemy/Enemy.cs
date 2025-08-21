using UnityEngine;

public class Enemy : MonoBehaviour, IStateMachine<Enemy>
{
    private EnemyStateFactory _factory;
    private State<Enemy> _currentState;

    public State<Enemy> CurrentState { get { return _currentState; } set { _currentState = value; } }

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
        _factory = new EnemyStateFactory(this);
        _currentState = _factory.InitialState;
        _currentState.OnEnter();
    }
}