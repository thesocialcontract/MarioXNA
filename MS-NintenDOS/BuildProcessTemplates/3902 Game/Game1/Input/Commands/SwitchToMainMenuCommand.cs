using Game1.Scenes;
using Game1.Scenes.MenuSceneStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Input.Commands
{
    class SwitchToMainMenuCommand : ICommand
    {
        MenuScene Menu;
        public SwitchToMainMenuCommand(MenuScene menu)
        {
            Menu = menu;
        }
        public void Execute()
        {
            Menu.MenuSceneState = new MainMenuSceneState(Menu);
        }
    }
}
