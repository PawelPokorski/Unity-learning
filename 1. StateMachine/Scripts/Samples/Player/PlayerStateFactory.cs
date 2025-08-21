using System.Collections.Generic;

public class PlayerStateFactory : IStateFactory<Player>
{
    private readonly Player _context;
    private readonly Dictionary<PlayerStates, PlayerState> _states = new();

    public State<Player> InitialState { get { return Grounded(); } }

    public PlayerStateFactory(Player context)
    {
        _context = context;

        _states[PlayerStates.Grounded] = new PlayerGroundedState(_context, this);
        _states[PlayerStates.Idle] = new PlayerIdleState(_context, this);
    }

    public PlayerState Grounded() { return _states[PlayerStates.Grounded]; }
    public PlayerState Idle() { return _states[PlayerStates.Idle]; }
}

enum PlayerStates
{
    Grounded,
    Idle
}