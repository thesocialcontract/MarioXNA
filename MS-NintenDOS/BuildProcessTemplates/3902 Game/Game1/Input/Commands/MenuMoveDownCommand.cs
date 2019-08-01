using Game1.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Input.Commands
{
    public class MenuMoveDownCommand : ICommand
    {
        MenuScene Menu;
        public MenuMoveDownCommand(MenuScene menu)
        {
            Menu = menu;
        }
        public void Execute()
        {
            
            Menu.MoveDown();
        }
 
    }
}
