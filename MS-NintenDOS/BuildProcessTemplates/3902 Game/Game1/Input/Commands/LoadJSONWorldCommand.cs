using Game1.Scenes;
using Game1.WorldLoading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Input.Commands
{
    class LoadJSONWorldCommand : ICommand
    {
        MenuScene Menu;
        public LoadJSONWorldCommand(MenuScene menu)
        {
            Menu = menu;
        }
        public void Execute()
        {
            SceneManager.Instance.LoadScene(new WorldScene(WorldHelpers.FirstLevelFilepath, WorldHelpers.StartingLives, Menu.Player));
        }
    }
}
