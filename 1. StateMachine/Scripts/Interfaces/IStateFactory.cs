public interface IStateFactory<T> where T : class
{
    State<T> InitialState { get; }
}