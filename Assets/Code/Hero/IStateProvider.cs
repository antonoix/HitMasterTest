public interface IStateProvider
{
    void SetState<T>() where T : HeroState;
}
