using Game1.Scenes;

namespace Game1.Input.Commands
{
    class StopRunCommand : ICommand
    {
        WorldScene mainScene;

        public StopRunCommand(WorldScene scene)
        {
            mainScene = scene;
        }

        public void Execute()
        {
            mainScene.Level.Player.SpeedButtonPress(false);
        }

    }
}
