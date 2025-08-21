using System.Collections.Generic;

public class EnemyStateFactory : IStateFactory<Enemy>
{
    private readonly Enemy _context;
    private readonly Dictionary<EnemyStates, EnemyState> _states = new();

    public State<Enemy> InitialState { get { return Idle(); } }

    public EnemyStateFactory(Enemy context)
    {
        _context = context;

        _states[EnemyStates.Idle] = new EnemyIdleState(_context, this);
    }

    public EnemyState Idle() { return _states[EnemyStates.Idle]; }
}

enum EnemyStates
{
    Idle
}