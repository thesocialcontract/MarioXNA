using Game1.Scenes;

namespace Game1.Input.Commands
{
    class GoDownCommand : ICommand
    {
        WorldScene mainScene;

        public GoDownCommand(WorldScene scene)
        {
            mainScene = scene;
        }

        public void Execute()
        {
            mainScene.Level.Player.Crouch();
            mainScene.Level.Player.MoveDown();
        }

    }
}
