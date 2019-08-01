using Game1.Scenes;

namespace Game1.Input.Commands
{
    class MoveLeftCommand : ICommand
    {
        WorldScene mainScene;

        public MoveLeftCommand(WorldScene scene)
        {
            mainScene = scene;
        }

        public void Execute()
        {
            
            mainScene.Level.Player.RunLeft();
            mainScene.Level.Player.MoveLeft();
        }

    }
}
