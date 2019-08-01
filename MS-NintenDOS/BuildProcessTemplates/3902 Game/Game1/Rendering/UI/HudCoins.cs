using Game1.WorldLoading;

namespace Game1.Rendering.UI
{
    public class HudCoins : IHudMember
    {
        int Coins;
        
        IHudMember AddLives;

        public string StringValue { get; set; }

        public HudCoins(int InitialValue, IHudMember Lives)
        {
            Coins = InitialValue;
            
            
            StringValue = " x ";
            AddLives = Lives;
            CalculateValue();
        }
        public void AddValue(int value)
        {
            Coins = Coins + value;
            CalculateValue();
        }

        public void SetValue(int value)
        {
            Coins = value;
            CalculateValue();
        }

        public void CalculateValue()
        {
            Coins = World.Instance.Player.Coins;
            if(Coins > 99)
            {
                int Difference = Coins - 99;
                AddLives.AddValue(1);
                Coins = Difference;
            }
                      
            StringValue = " x ";
            if(Coins < 10)
            {
                StringValue = StringValue + 0;
            }
            StringValue = StringValue + Coins;
            
        }
        

    }
}
