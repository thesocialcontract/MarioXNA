using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Input;
using Game1.Input.Commands;


namespace Game1.Input.Controllers
{
    class KeyboardController : IController
    {
        public Dictionary<Keys, HashSet<ICommand>> CommandList;
        public Dictionary<Keys, HashSet<ICommand>> ReleaseCommandList;
        public bool IsDisabled;
        
               
        private HashSet<Keys> recentlyPressed;

        public KeyboardController()
        {
            
            CommandList = new Dictionary<Keys, HashSet<ICommand>>();
            ReleaseCommandList = new Dictionary<Keys, HashSet<ICommand>>();
            
            recentlyPressed = new HashSet<Keys>();
            IsDisabled = false;
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            if (CommandList.ContainsKey(key))
            {
                CommandList[key].Add(command);
            }
            else
            {
                HashSet<ICommand> commands = new HashSet<ICommand>() { command };
                CommandList.Add(key, commands);
            }
        }

        public void RegisterReleaseCommand(Keys key, ICommand command)
        {
            if (ReleaseCommandList.ContainsKey(key))
            {
                ReleaseCommandList[key].Add(command);
            }
            else
            {
                HashSet<ICommand> commands = new HashSet<ICommand>() { command };
                ReleaseCommandList.Add(key, commands);
            }
        }

       

        public void Update()
        {
            if (!IsDisabled)
            {
                Keys[] PressedKeys = Keyboard.GetState().GetPressedKeys();

                if (PressedKeys.Length > 0)
                {
                    foreach (Keys pressedKey in PressedKeys)
                    {
                        if (CommandList.ContainsKey(pressedKey))
                        {

                            foreach (ICommand command in CommandList[pressedKey])
                            {
                                command.Execute();
                            }
                        }
                    }

                }

                foreach (Keys RecentlyPressedKey in recentlyPressed.ToList())
                {
                    if (!(PressedKeys.Contains(RecentlyPressedKey)))
                    {
                        recentlyPressed.Remove(RecentlyPressedKey);
                        if (ReleaseCommandList.ContainsKey(RecentlyPressedKey))
                        {
                            foreach (ICommand command in ReleaseCommandList[RecentlyPressedKey])
                            {
                                command.Execute();
                            }
                        }
                    }

                }
                foreach (Keys PressedKey in PressedKeys)
                {
                    if (!(recentlyPressed.Contains(PressedKey)))
                    {
                        recentlyPressed.Add(PressedKey);
                    }
                }
            }
        }
        public void SetDisabled(bool Disability)
        {
            IsDisabled = Disability;
        }

    }
}