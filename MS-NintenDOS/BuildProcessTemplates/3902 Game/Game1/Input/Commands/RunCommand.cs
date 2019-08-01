using Game1.Scenes;

namespace Game1.Input.Commands
{
    class RunCommand : ICommand
    {
        WorldScene mainScene;

        public RunCommand(WorldScene scene)
        {
            mainScene = scene;
        }

        public void Execute()
        {
            mainScene.Level.Player.SpeedButtonPress(true);

        }

    }
}
