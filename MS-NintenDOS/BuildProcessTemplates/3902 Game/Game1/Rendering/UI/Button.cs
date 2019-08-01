using Game1.Input.Commands;
using Globals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Rendering.UI
{
    public class Button
    {
        private Vector2 RelativeDrawPosition { get; set; }
        private Vector2 Origin { get; set; }
        private string DisplayString { get; set; }
        private ICommand SelectCommand { get; set; }
        private ISprite HoverSprite { get; }
        public bool IsHovered { get; set; }
        public Button(string displayString, Vector2 relativeDrawPostion, ICommand selectCommand)
        {
            RelativeDrawPosition = relativeDrawPostion;
            DisplayString = displayString;
            SelectCommand = selectCommand;
            HoverSprite = SpriteFactory.Instance.CreateSprite("Triangle");
        }
        public void Select()
        {
            SelectCommand.Execute();
        }
        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            Vector2 size = font.MeasureString(DisplayString);
            Vector2 origin = size * 0.5f;
            Vector2 pos = new Vector2(
                (GameGlobals.ScreenWidth) * RelativeDrawPosition.X, 
                (GameGlobals.ScreenHeight) * RelativeDrawPosition.Y);
            
            if (IsHovered)
            {
                Vector2 HoverSpriteLocation = new Vector2(pos.X - HoverSprite.Width - (size.X/2) , pos.Y - (size.Y/2));
                HoverSprite.Draw(spriteBatch, HoverSpriteLocation);
            }
            spriteBatch.DrawString(font, DisplayString, pos, Color.White, 0, origin, 1, SpriteEffects.None, 0);
        }
    }
}
