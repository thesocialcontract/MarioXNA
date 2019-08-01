using Game1.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Input.Commands
{
    class MenuMoveUpCommand : ICommand
    {
        MenuScene Menu;
        public MenuMoveUpCommand(MenuScene menu)
        {
            Menu = menu;
        }
        public void Execute()
        {
            Menu.MoveUp();
        }
    }
}
