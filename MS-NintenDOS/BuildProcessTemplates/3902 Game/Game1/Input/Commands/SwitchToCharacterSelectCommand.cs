using Game1.Scenes;
using Game1.Scenes.MenuSceneStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Input.Commands
{
    public class SwitchToCharacterSelectCommand : ICommand
    {
        private MenuScene MenuScene;
        public SwitchToCharacterSelectCommand(MenuScene menuScene)
        {
            MenuScene = menuScene;
        }
        public void Execute()
        {
            MenuScene.MenuSceneState = new CharacterSelectMenuSceneState(MenuScene);
        }
    }
}
