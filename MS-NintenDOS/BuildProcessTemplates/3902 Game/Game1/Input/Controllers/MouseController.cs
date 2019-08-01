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
    public class MouseController
    {
        
        Game1 MainGame;
        ICommand MouseUpCommand;
        ICommand MouseLeftCommand;
        ICommand MouseRightCommand;
        ICommand MouseDownCommand;
        ICommand MouseStopCommand;
        bool MouseControllerToggle;

        public MouseController(Game1 mainGame)
        {

                        
            MainGame = mainGame;
            MouseUpCommand = new GoUpCommand(MainGame);
            MouseLeftCommand = new MoveLeftCommand(MainGame);
            MouseRightCommand = new MoveRightCommand(MainGame);
            MouseDownCommand = new GoDownCommand(MainGame);
            MouseStopCommand = new StandCommand(MainGame);
            MouseControllerToggle = false;
        }

 //       public void RegisterCommand(int Direction, ICommand command) 
   //     {

     //       CommandList.Add(Direction, command);
       // }

        public void ToggleOnOrOff()
        {
            MouseControllerToggle = !MouseControllerToggle;
        }

        public void Update()
        {
           
            if(MouseControllerToggle)
            {
                MouseState PositionOfMouse = Mouse.GetState();
                int XPositionOfMouse = PositionOfMouse.X;
                int YPositionOfMouse = PositionOfMouse.Y;

                int MariosXDifference = CalculateXDifference(XPositionOfMouse);
                int MariosYDifference = CalculateYDifference(YPositionOfMouse);
                if (!((MariosXDifference == 0) && (MariosYDifference == 0)))
                {
                
                    if (MariosXDifference > 0)
                    {
                        MouseRightCommand.Execute();

                    }
                    else if (MariosXDifference < 0)
                    {
                        MouseLeftCommand.Execute();
                    }
                    if (MariosYDifference > 0)
                    {
                    MouseDownCommand.Execute();

                    }
                    else if (MariosYDifference < 0)
                    {
                        MouseUpCommand.Execute();
                    }
                
                }else
                {
                MouseStopCommand.Execute();
                }
            }
        }
        

        private int CalculateXDifference(int XMousePosition)
        {
            int MariosXPosition = MainGame.Level.Player.XPos;

            return XMousePosition - MariosXPosition;

        }

        private int CalculateYDifference(int YMousePosition)
        {
            int MariosYPosition = MainGame.Level.Player.YPos;

            return YMousePosition - MariosYPosition;

        }

    }
}