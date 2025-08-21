public abstract class EnemyState : State<Enemy>
{
    private readonly Enemy _context;
    private readonly EnemyStateFactory _factory;

    protected Enemy Context { get { return _context; } }
    protected EnemyStateFactory Factory { get { return _factory; } }

    protected EnemyState(Enemy context, EnemyStateFactory factory)
        : base(context, factory)
    {
        _context = context;
        _factory = factory;
    }
}