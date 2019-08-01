using Game1.WorldLoading;

namespace Game1.Rendering.UI
{
    public class HudLives : IHudMember
    {
        int Lives;
                
        public string StringValue { get; set; }

        public HudLives(int InitialValue)
        {
            Lives = InitialValue;
                        
            StringValue = " x ";
            CalculateValue();
        }

        public void AddValue(int value)
        {
            Lives = Lives + value;
            CalculateValue();
        }

        public void SetValue(int value)
        {
            Lives = value;
            CalculateValue();
        }
        
        public void CalculateValue()
        {
            Lives = World.Instance.Player.Lives;
            StringValue = " x ";
            StringValue = StringValue + Lives;
        }
    }
}
