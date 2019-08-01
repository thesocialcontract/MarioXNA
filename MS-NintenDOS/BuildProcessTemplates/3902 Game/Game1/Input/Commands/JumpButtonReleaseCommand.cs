using Game1.Scenes;

namespace Game1.Input.Commands
{
    class JumpButtonReleaseCommand : ICommand
    {
        WorldScene mainScene;

        public JumpButtonReleaseCommand(WorldScene scene)
        {
            mainScene = scene;
        }

        public void Execute()
        {
            mainScene.Level.Player.SetEndUpwardForce(true);
            mainScene.Level.Player.SetSingleJump(false);
            
        }

    }
}
