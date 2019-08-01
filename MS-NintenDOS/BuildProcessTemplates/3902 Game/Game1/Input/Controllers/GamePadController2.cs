using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class GamepadController2
    {
        public Dictionary<Buttons, HashSet<ICommand>> CommandList;
        public Dictionary<Buttons, HashSet<ICommand>> ReleaseCommandList;
        
               
        private HashSet<Buttons> recentlyPressed;
        

        public GamepadController2()
        {
            
            CommandList = new Dictionary<Buttons, HashSet<ICommand>>();
            ReleaseCommandList = new Dictionary<Buttons, HashSet<ICommand>>();
            
            recentlyPressed = new HashSet<Buttons>();
          
        }

        public void RegisterCommand(Buttons button, ICommand command)
        {
            if (CommandList.ContainsKey(button))
            {
                CommandList[button].Add(command);
            }
            else
            {
                HashSet<ICommand> commands = new HashSet<ICommand>() { command };
                CommandList.Add(button, commands);
            }
        }

        public void RegisterReleaseCommand(Buttons button, ICommand command)
        {
            if (ReleaseCommandList.ContainsKey(button))
            {
                ReleaseCommandList[button].Add(command);
            }
            else
            {
                HashSet<ICommand> commands = new HashSet<ICommand>() { command };
                ReleaseCommandList.Add(button, commands);
            }
        }



        public void Update()
        {
            HashSet<Buttons> ButtonsPress = new HashSet<Buttons>();

            if (GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.A))
          {
                        ButtonsPress.Add(Buttons.A);
          }
            if (GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.B))
            {
                ButtonsPress.Add(Buttons.B);
            }
            if (GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.DPadDown))
            {
                ButtonsPress.Add(Buttons.DPadDown);
            }
            if (GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.DPadLeft))
            {
                ButtonsPress.Add(Buttons.DPadLeft);
            }

            if (GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.DPadRight))
            {
                ButtonsPress.Add(Buttons.DPadRight);
            }

            foreach(Buttons button in ButtonsPress)
            {
                if(CommandList.ContainsKey(button))
                {
                    foreach (ICommand command in CommandList[button])
                    {
                        command.Execute();
                    }
                }
            }

            foreach (Buttons RecentlyPressedButton in recentlyPressed.ToList())
            {
                if(!(ButtonsPress.Contains(RecentlyPressedButton)))
                {
                    recentlyPressed.Remove(RecentlyPressedButton);
                    if (ReleaseCommandList.ContainsKey(RecentlyPressedButton))
                    {
                        foreach(ICommand command in ReleaseCommandList[RecentlyPressedButton])
                        {
                            command.Execute();
                        }
                    }
                }
                
            }
            foreach (Buttons PressedButton in ButtonsPress)
            {
                if (!(recentlyPressed.Contains(PressedButton)))
                {
                    recentlyPressed.Add(PressedButton);
                }
            }

        }
        

    }
}