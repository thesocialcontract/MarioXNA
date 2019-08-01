using Game1.WorldLoading;

namespace Game1.Input.Commands
{
    class PauseLevelCommand : ICommand
    {
        IWorld world;

        public PauseLevelCommand(IWorld world)
        {
            this.world = world;
        }

        public void Execute()
        {
            world.Pause();
        }
    }
}
