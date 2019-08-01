using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Rendering
{
    class AnimatedHudSprite : IHudSprite
    {
        
            public Texture2D Texture { get; set; }
            public int Rows { get; set; }
            public int Columns { get; set; }
            private int currentFrame;
            private int totalFrames;
        private int Delay;
        private int DelayAmount;

            Vector2 Location;
            SpriteBatch HudSpriteBatch;

            public AnimatedHudSprite(Texture2D texture, int rows, int columns, Vector2 InputLocation, SpriteBatch InputHudSpriteBatch)
            {
                Texture = texture;
                Rows = rows;
                Columns = columns;
                currentFrame = 0;
                totalFrames = Rows * Columns;
                Location = InputLocation;
                HudSpriteBatch = InputHudSpriteBatch;
            DelayAmount = 20;
            Delay = DelayAmount;
            }

            public void Update()
            {
            Delay--;
            if(Delay == 0)
            {
                currentFrame++;
                if (currentFrame >= totalFrames)
                    currentFrame = 0;
                Delay = DelayAmount;
            }
                
            }

            public void Draw()
            {
                int width = Texture.Width / Columns;
                int height = Texture.Height / Rows;
                int row = (int)((float)currentFrame / (float)Columns);
                int column = currentFrame % Columns;

                Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
                Rectangle destinationRectangle = new Rectangle((int)Location.X, (int)Location.Y, width*2, height*2);
                            
                HudSpriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
                
            }
    }

    
}
