using Game1.Input.Commands;
using Game1.Rendering.UI;
using Globals;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Scenes.MenuSceneStates
{
    public class MainMenuSceneState : MenuSceneState
    {
        string MenuTitleString;
        Vector2 TitleStringSize;
        Vector2 TitleStringOrigin;
        Vector2 Position;
        private bool selectionMade;
        private int timer;
        public MainMenuSceneState(MenuScene menuScene) : base(menuScene)
        {
            MenuTitleString = "MS-Mario [re:PLAY] ver. 2 rev. 1.07";
            TitleStringSize = menuScene.MenuText.MeasureString(MenuTitleString);
            TitleStringOrigin = TitleStringSize * 0.5f;
            Vector2 RelativeDrawPosition = new Vector2(0.5f, 0.2f);
            Position = new Vector2(
                (GameGlobals.ScreenWidth) * RelativeDrawPosition.X,
                (GameGlobals.ScreenHeight) * RelativeDrawPosition.Y);
            string displayText = "Start Game";
            Vector2 relPos = new Vector2(0.5f, 0.5f);
            Buttons.Add(new Button(displayText, relPos, new SwitchToCharacterSelectCommand(MenuScene)));
            displayText = "Quit";
            relPos = new Vector2(0.5f, 0.6f);
            Buttons.Add(new Button(displayText, relPos, new QuitCommand(MenuScene)));
            selectionMade = false;
            timer = 0;
        }
        public override void Draw()
        {
            MenuScene.Game.spriteBatch.DrawString(MenuScene.MenuText, MenuTitleString, Position, Color.White, 0, TitleStringOrigin, 1.25f, Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 0);
            base.Draw();
        }
        public override void Update()
        {
            timer--;
            if(timer <= 0)
            {
                selectionMade = false;
            }
            if (!selectionMade)
            {
                Random random = new Random();
                int marioOrWario = random.Next(0, 99);
                if (marioOrWario < 10)
                {
                    MenuTitleString = "MS-Wario [re:PLAY] ver. 2 rev. 1.07";
                }
                else
                {
                    MenuTitleString = "MS-Mario [re:PLAY] ver. 2 rev. 1.07";
                }
                selectionMade = true;
                timer = 10;
            }
        }
        public override void GoBack()
        {
            MenuScene.Exit();
        }
    }    
}
