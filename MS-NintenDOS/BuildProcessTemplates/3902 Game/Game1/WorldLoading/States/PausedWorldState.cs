using Game1.Input;

namespace Game1.WorldLoading.States
{
    class PausedWorldState : AbstractWorldState
    {
        private CheatHandler cheatHandler;

        public PausedWorldState(IWorld world, float secondsLeft) : base(world, secondsLeft)
        {
            WorldAudioManager.Pause();
            cheatHandler = new CheatHandler(World);
        }

        public override void Pause()
        {
            World.State = new PlayingWorldState(World, SecondsLeft);
        }

        public override void CheatEntry(string key)
        {
            cheatHandler.Enter(key);
        }

    }
}
