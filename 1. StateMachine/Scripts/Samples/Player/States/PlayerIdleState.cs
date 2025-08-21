public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player context, PlayerStateFactory factory)
        : base(context, factory) { }

    public override void OnEnter() { }
    public override void OnUpdate() { }
    public override void OnExit() { }

    public override void CheckSwitchStates() { }
    public override void InitializeSubState() { }
}