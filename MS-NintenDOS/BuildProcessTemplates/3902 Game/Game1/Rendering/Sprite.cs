using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game1.Rendering
{
    public class Sprite : ISprite
    {
        private const int UpdatesPerFrame = 10;
        private const int UpdatesPerColorFrame = 5;

        public int Width => (int)(frameWidth * scale);
        public int Height => (int)(frameHeight * scale);

        private readonly int columns;
        private readonly int frames;
        private readonly float scale;
        private readonly int frameWidth;
        private readonly int frameHeight;
        private readonly ICollection<int> framesToUse;
        private static readonly Color red = new Color(new Color(255, 0, 0), 0.4f);
        private static readonly Color green = new Color(new Color(0, 255, 0), 0.3f);
        private static readonly Color blue = new Color(new Color(0, 0, 255), 0.1f);
        private static readonly Color[] colorsToUse = { blue, red, green };
        private int colorFrame;
        private int currentFrame = 0;
        private int updatesSinceFrame = 0;
        private int updatesSinceColorFrame = 0;
        private readonly Texture2D texture;

        public Sprite(Texture2D texture, SpriteRegistrar spriteRegistrar)
        { 
            this.texture = texture;
            columns = spriteRegistrar.Columns;
            frameWidth = texture.Width / spriteRegistrar.Columns;
            frameHeight = texture.Height / spriteRegistrar.Rows;
            scale = spriteRegistrar.Scale;
            framesToUse = spriteRegistrar.FramesToUse;
            frames = framesToUse.Count;
            Random random = new Random();
            colorFrame = random.Next(0, 3);
        }

        public void Update()
        {
            updatesSinceFrame = (updatesSinceFrame + 1) % UpdatesPerFrame;
            updatesSinceColorFrame = (updatesSinceColorFrame + 1) % UpdatesPerColorFrame;
            if (updatesSinceFrame == 0) {
                currentFrame = (currentFrame + 1) % frames;
            }
            if (updatesSinceColorFrame == 0)
            {
                colorFrame = (colorFrame + 1) % colorsToUse.Length;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int frameNumber = framesToUse.ElementAt(currentFrame);
            int row = frameNumber / columns;
            int column = frameNumber % columns;

            Rectangle sourceRectangle = new Rectangle(frameWidth * column, frameHeight * row, frameWidth, frameHeight);
            Rectangle destinationRectangle = new Rectangle((int) location.X, (int) location.Y,(int) (frameWidth*scale), (int)(frameHeight*scale));

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, float degrees)
        {
            int frameNumber = framesToUse.ElementAt(currentFrame);
            int row = frameNumber / columns;
            int column = frameNumber % columns;

            Rectangle sourceRectangle = new Rectangle(frameWidth * column, frameHeight * row, frameWidth, frameHeight);
            Rectangle destinationRectangle = new Rectangle((int) location.X, (int) location.Y,(int) (frameWidth*scale), (int) (frameHeight*scale));
            var origin = new Vector2(frameWidth / 2, frameHeight / 2);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, degrees, origin, SpriteEffects.None, 0.0f);
        }

        public void InvulnerableDraw(SpriteBatch spriteBatch, Vector2 location)
        {
            int frameNumber = framesToUse.ElementAt(currentFrame);
            int row = frameNumber / columns;
            int column = frameNumber % columns;
            Color currentColor = colorsToUse[colorFrame];

            Rectangle sourceRectangle = new Rectangle(frameWidth * column, frameHeight * row, frameWidth, frameHeight);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, (int)(frameWidth * scale), (int)(frameHeight * scale));

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, currentColor);
        }
    }
}
