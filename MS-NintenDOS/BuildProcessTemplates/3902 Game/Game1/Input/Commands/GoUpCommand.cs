using Game1.Scenes;

namespace Game1.Input.Commands
{
    class GoUpCommand : ICommand
    {
        WorldScene mainScene;

        public GoUpCommand(WorldScene scene)
        {
            mainScene = scene;
        }

        public void Execute()
        {
            mainScene.Level.Player.Jump();
            mainScene.Level.Player.SetSingleJump(true);
            

        }

    }
}
