namespace Game1.WorldLoading.States
{
    public interface IWorldState : IUpdatable, IDrawable
    {
        void WorldResume();
        void Pause();
        void Reset(float secondsLeft);
        void CheatEntry(string key);
        float SecondsLeft { get; }
    }
}
