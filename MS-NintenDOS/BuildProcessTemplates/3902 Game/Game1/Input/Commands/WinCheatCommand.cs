using Game1.Audio;
using Game1.Entities.Mario;
using Game1.Rendering.UI;
using Game1.WorldLoading;
using Game1.WorldLoading.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Input.Commands
{
    public class WinCheatCommand:ICommand
    {
        private IWorld world;

        public WinCheatCommand(IWorld world)
        {
            this.world = world;
        }

        public void Execute()
        {
            world.Player = new InvisibleWinMario((Mario)world.Player);
            WorldAudioManager.PlayMusicWin();
        }
    }
}
