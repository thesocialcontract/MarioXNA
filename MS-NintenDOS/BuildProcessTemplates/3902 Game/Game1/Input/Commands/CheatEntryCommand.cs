using Game1.Scenes;

namespace Game1.Input.Commands
{
    public class CheatEntryCommand : ICommand
    {
        WorldScene mainScene;
        private string key;

        public CheatEntryCommand(WorldScene scene, string key)
        {
            mainScene = scene;
            this.key = key;
        }

        public void Execute()
        {
            mainScene.CheatEntry(key);
        }

    }
}
