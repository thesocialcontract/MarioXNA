using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class GamepadController
    {

        private Dictionary<Buttons, ICommand> ButtonCommandList;
        private HashSet<Buttons> recentlyPressed;
        private ICommand GamepadUpCommand;
        private ICommand GamepadLeftCommand;
        private ICommand GamepadRightCommand;
        private ICommand GamepadDownCommand;
        private ICommand GamepadStopCommand;
        public GamepadController(Game1 game)
        {
            ButtonCommandList = new Dictionary<Buttons, ICommand>();
            GamepadDownCommand = new GoDownCommand(game);
            GamepadUpCommand = new GoUpCommand(game);
            GamepadLeftCommand = new MoveLeftCommand(game);
            GamepadRightCommand = new MoveRightCommand(game);
            GamepadStopCommand = new StandCommand(game);
            recentlyPressed = new HashSet<Buttons>();
        }
        public void RegisterCommand(Buttons button, ICommand command)
        {
            ButtonCommandList.Add(button, command);
        }
        public void Update()
        {
            Buttons[] Inputs = ButtonCommandList.Keys.ToArray();
            if(GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X > 0.5f)
            {
                GamepadRightCommand.Execute();
            }
            else if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X < -0.5f)
            {
                GamepadLeftCommand.Execute();
            } 
            else
            {
                //TODO properly implement GamePad so we can implement this
                //this.GamepadStopCommand.Execute();
            }
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y > 0.5f)
            {
                GamepadUpCommand.Execute();
            }
            else if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y < -0.5f)
            {
                GamepadDownCommand.Execute();
            }
            else
            {
                //TODO properly implement Gamepad so we can keep this
                //this.GamepadStopCommand.Execute();
            }
            foreach (Buttons button in Inputs)
            {
                if (GamePad.GetState(PlayerIndex.One).IsButtonDown(button))
                {
                    ButtonCommandList[button].Execute();
                }
            }
        }
    }
}