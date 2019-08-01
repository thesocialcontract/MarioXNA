using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.WorldLoading;

namespace Game1.Rendering.UI
{
    public class GameHud
    {

        
        SpriteBatch HudspriteBatch;
        SpriteFont TextFont;

        bool IsHidden;
        bool MidScreen;
        
        
        IHudMember PlayerScore;
        IHudMember PlayerLives;
        IHudMember PlayerCoins;
        IHudMember PlayerWorld;
        IHudMember PlayerTime;

        Vector2 LivesPosition = new Vector2(440, 180);
        Vector2 CoinsPosition = new Vector2(310, 25);
        Vector2 CoinsSpritePosition = new Vector2(295, 30);
        Vector2 ScorePosition = new Vector2(70, 25);
        Vector2 PlayerNamePosition = new Vector2(70, 5);
        Vector2 TimeNamePosition = new Vector2(675, 5);
        Vector2 TimePosition = new Vector2(700, 25);
        Vector2 WorldNamePosition = new Vector2(450, 5);
        Vector2 WorldValuePosition = new Vector2(470, 25);

        Vector2 MidScreenWorldPosition = new Vector2(400, 100);
        Vector2 MidScreenWorldValuePosition = new Vector2(430, 130);
        Vector2 MidScreenMarioPosition = new Vector2(400, 180);
        Texture2D MarioHead;
        Texture2D HudCoin;

        IHudSprite CoinSprite;
        IHudSprite MarioSprite;

        string Name;
        string StringLives;
        string StringCoins;
        string StringScore;
        string StringTime;
        string StringOutput;
        

        private GameHud()
        {
            PlayerScore = new HudScore(0);
            PlayerLives = new HudLives(WorldHelpers.StartingLives);
            PlayerCoins = new HudCoins(0, PlayerLives);
            PlayerWorld = new HudWorld(1, 1);
            PlayerTime = new HudTimer();
            StringLives = PlayerLives.StringValue;
            StringCoins = PlayerCoins.StringValue;
            StringScore = PlayerScore.StringValue;
            StringTime = PlayerTime.StringValue;
            StringOutput = PlayerWorld.StringValue;
            IsHidden = false;
            MidScreen = false;
            

            CoinSprite = new AnimatedHudSprite(HudCoin, 1, 3, CoinsSpritePosition, HudspriteBatch);
            MarioSprite = new AnimatedHudSprite(MarioHead, 1, 1, MidScreenMarioPosition, HudspriteBatch);
        }

        public static GameHud Instance { get; set; } = new GameHud();

        public static GameHud ResetHUD(SpriteBatch InputHudspriteBatch, SpriteFont InputTextFont, string InputName, Texture2D CoinsTexture, Texture2D LivesTexture)
        {
            Instance.HudspriteBatch = InputHudspriteBatch;
            Instance.TextFont = InputTextFont;
            Instance.Name = InputName;
            Instance.PlayerScore = new HudScore(0);
            Instance.PlayerLives = new HudLives(WorldHelpers.StartingLives);
            Instance.PlayerCoins = new HudCoins(0, Instance.PlayerLives);
            Instance.PlayerWorld = new HudWorld(1, 1);
            Instance.PlayerTime = new HudTimer();
            Instance.StringLives = Instance.PlayerLives.StringValue;
            Instance.StringCoins = Instance.PlayerCoins.StringValue;
            Instance.StringScore = Instance.PlayerScore.StringValue;
            Instance.StringTime = Instance.PlayerTime.StringValue;
            Instance.StringOutput = Instance.PlayerWorld.StringValue;
            Instance.IsHidden = false;
            Instance.MidScreen = false;
            Instance.HudCoin = CoinsTexture;
            Instance.MarioHead = LivesTexture;
            
            Instance.CoinSprite = new AnimatedHudSprite(Instance.HudCoin, 1, 3, Instance.CoinsSpritePosition, Instance.HudspriteBatch);
            Instance.MarioSprite = new AnimatedHudSprite(Instance.MarioHead, 1, 1, Instance.MidScreenMarioPosition, Instance.HudspriteBatch);

            return Instance;
        }

        public void SetVisibility(bool NotSeen)
        {
            IsHidden = NotSeen;
        }
        
        public void SetMidScreen(bool Seen)
        {
            MidScreen = Seen;
        }

        public void Update()
        {
            PlayerTime.CalculateValue();
            PlayerLives.CalculateValue();
            PlayerScore.CalculateValue();
            PlayerCoins.CalculateValue();
            StringLives = PlayerLives.StringValue;
            StringCoins = PlayerCoins.StringValue;
            StringScore = PlayerScore.StringValue;
            StringTime = PlayerTime.StringValue;
            StringOutput = PlayerWorld.StringValue;
            CoinSprite.Update();
            MarioSprite.Update();
        }

        public void Draw()
        {
            if ((!IsHidden) && (!MidScreen))
            {
                HudspriteBatch.DrawString(TextFont, StringCoins, CoinsPosition, Color.White);
                CoinSprite.Draw();
                HudspriteBatch.DrawString(TextFont, Name, PlayerNamePosition, Color.White);
                HudspriteBatch.DrawString(TextFont, StringScore, ScorePosition, Color.White);
                HudspriteBatch.DrawString(TextFont, "TIME", TimeNamePosition, Color.White);
                                
                HudspriteBatch.DrawString(TextFont, StringTime, TimePosition, Color.White);
                HudspriteBatch.DrawString(TextFont, "WORLD", WorldNamePosition, Color.White);
                HudspriteBatch.DrawString(TextFont, StringOutput, WorldValuePosition, Color.White);
            }
            if (MidScreen && (!IsHidden))
            {
                HudspriteBatch.DrawString(TextFont, "WORLD", MidScreenWorldPosition, Color.White);
                HudspriteBatch.DrawString(TextFont, StringOutput, MidScreenWorldValuePosition, Color.White);
                HudspriteBatch.DrawString(TextFont, StringLives, LivesPosition, Color.White);
                MarioSprite.Draw();
            }
        }
        public void SetLives(int value)
        {
            PlayerLives.SetValue(value);
        }
    }
}
