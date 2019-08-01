using Game1.Scenes;

namespace Game1.Input.Commands
{
    class StandCommand : ICommand
    {
        WorldScene mainScene;

        public StandCommand(WorldScene scene)
        {
            mainScene = scene;
        }

        public void Execute()
        {
            mainScene.Level.Player.Stand();
        }

    }
}
