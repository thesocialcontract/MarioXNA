using Game1.Entities.Mario;
using Game1.Scenes;
using Game1.Scenes.MenuSceneStates;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Input.Commands
{
    class SwitchToLevelSelectWarioCommand : ICommand
    {
        MenuScene Menu;
        public SwitchToLevelSelectWarioCommand(MenuScene menu)
        {
            Menu = menu;
        }
        public void Execute()
        {
            Menu.Player = new Wario(new Vector2(0, 0));
            Menu.MenuSceneState = new LevelSelectSceneState(Menu);
        }
    }
}
