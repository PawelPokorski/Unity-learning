public class EnemyIdleState : EnemyState
{
    public EnemyIdleState(Enemy context, EnemyStateFactory factory)
        : base(context, factory) { }

    public override void OnEnter() { }
    public override void OnUpdate() { }
    public override void OnExit() { }

    public override void CheckSwitchStates() { }
    public override void InitializeSubState() { }
}