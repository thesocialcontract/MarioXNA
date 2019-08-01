using Game1.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Input.Commands
{
    class MenuGoBackCommand : ICommand
    {
        MenuScene Menu;
        public MenuGoBackCommand(MenuScene menu)
        {
            Menu = menu;
        }
        public void Execute()
        {
            Menu.GoBack();
        }
    }
}
