using Game1.Scenes;

namespace Game1.Input.Commands
{
    class QuitCommand : ICommand
    {
        IScene mainScene;
       
        public QuitCommand(IScene scene)
        {
            mainScene = scene;
            
        }

        public void Execute()
        {
            mainScene.Exit();
        }

    }
}
