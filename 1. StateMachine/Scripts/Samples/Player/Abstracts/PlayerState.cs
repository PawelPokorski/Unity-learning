public abstract class PlayerState : State<Player>
{
    private readonly Player _context;
    private readonly PlayerStateFactory _factory;

    protected Player Context { get { return _context; } }
    protected PlayerStateFactory Factory { get { return _factory; } }

    protected PlayerState(Player context, PlayerStateFactory factory)
        : base(context, factory)
    {
        _context = context;
        _factory = factory;
    }
}