using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Rendering;

namespace Game1
{
    class RisingText : IRisingText
    {
        
        SpriteFont RisingTextFont;
        Vector2 TextPosition;
        float HeightIncrementor;
        public int Timer { get; set; }
        string Value;
        
        

        public RisingText(SpriteFont InputSpriteFont)
        {

            RisingTextFont = InputSpriteFont;
            TextPosition = new Vector2(0f, 0f);
            HeightIncrementor = -2;
            Value = "";
            Timer = 0;
            
        }

        public RisingText(SpriteFont InputSpriteFont, Vector2 InputTextPosition, int InputValue)
        {
           
            RisingTextFont = InputSpriteFont;
            TextPosition = InputTextPosition;
            HeightIncrementor = -2;
            Value = InputValue.ToString();
            Timer = 60;
            
        }

        public void Update()
        {
            if (Timer > 0)
            { 
            Timer--;
            TextPosition = new Vector2(TextPosition.X, TextPosition.Y + HeightIncrementor);
                if (Timer <= 0)
                {
                Timer = 0;
                }
            }        

        }

        public void Draw()
        {
            if (Timer > 0)
            { 
            TextureList.Instance.GameSpriteBatch.DrawString(RisingTextFont, Value, TextPosition, Color.White);
            }
        }

        

    }
}
