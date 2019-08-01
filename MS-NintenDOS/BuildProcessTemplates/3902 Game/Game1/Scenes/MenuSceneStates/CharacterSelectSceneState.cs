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
    public class CharacterSelectMenuSceneState : MenuSceneState
    {
        string MenuTitleString;
        Vector2 TitleStringSize;
        Vector2 TitleStringOrigin;
        Vector2 Position;
        public CharacterSelectMenuSceneState(MenuScene menuScene) : base(menuScene)
        {
            MenuTitleString = "Choose Your Character";
            TitleStringSize = menuScene.MenuText.MeasureString(MenuTitleString);
            TitleStringOrigin = TitleStringSize * 0.5f;
            Vector2 RelativeDrawPosition = new Vector2(0.5f, 0.35f);
            Position = new Vector2(
                (GameGlobals.ScreenWidth) * RelativeDrawPosition.X,
                (GameGlobals.ScreenHeight) * RelativeDrawPosition.Y);
            string displayText = "Mario";
            Vector2 relPos = new Vector2(0.5f, 0.5f);
            Buttons.Add(new Button(displayText, relPos, new SwitchToLevelSelectMarioCommand(MenuScene)));
            displayText = "Wario";
            relPos = new Vector2(0.5f, 0.6f);
            Buttons.Add(new Button(displayText, relPos, new SwitchToLevelSelectWarioCommand(MenuScene)));
            displayText = "Go Back";
            relPos = new Vector2(0.5f, 0.7f);
            Buttons.Add(new Button(displayText, relPos, new SwitchToMainMenuCommand(MenuScene)));
        }
        public override void Draw()
        {
            MenuScene.Game.spriteBatch.DrawString(MenuScene.MenuText, MenuTitleString, Position, Color.White, 0, TitleStringOrigin, 1.125f, Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 0);
            base.Draw();
        }
        public override void GoBack()
        {
            MenuScene.MenuSceneState = new MainMenuSceneState(MenuScene);
        }
    }
}
