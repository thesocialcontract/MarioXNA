using Game1.WorldLoading;

namespace Game1.Input.Commands
{
    class ResetCommand : ICommand
    {
        public ResetCommand()
        {
        }

        public void Execute()
        {
            World.Instance.Start(WorldHelpers.FirstLevelFilepath);
        }

    }
}
