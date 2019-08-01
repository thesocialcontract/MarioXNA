using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class MouseToggleCommand : ICommand
    {
        MouseController mouse;

        public MouseToggleCommand(MouseController mouseInput)
        {
            mouse = mouseInput;
        }

        public void Execute()
        {
            mouse.ToggleOnOrOff();
            
        }

    }
}
