using Game1.Scenes;

namespace Game1.Input.Commands
{
    class MoveRightCommand : ICommand
    {
        WorldScene mainScene;

        public MoveRightCommand(WorldScene scene)
        {
            mainScene = scene;
        }

        public void Execute()
        {
            
            mainScene.Level.Player.RunRight();
            mainScene.Level.Player.MoveRight();
        }

    }
}
