using Game1.WorldLoading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Input.Commands
{
    public class StarCheatCommand:ICommand
    {
        private IWorld world;

        public StarCheatCommand(IWorld world)
        {
            this.world = world;
        }

        public void Execute()
        {
            world.Player.SetStar();
        }
    }
}
