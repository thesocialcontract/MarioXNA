using Game1.Scenes;

namespace Game1.Input.Commands
{
    class FireballCommand : ICommand
    {
        WorldScene mainScene;

        public FireballCommand(WorldScene scene)
        {
            mainScene = scene;
        }

        public void Execute()
        {
            mainScene.Level.Player.SpecialAbility();
        }

    }
}
