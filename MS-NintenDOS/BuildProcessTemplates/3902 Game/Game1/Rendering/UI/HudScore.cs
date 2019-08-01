using Game1.WorldLoading;

namespace Game1.Rendering.UI
{
    public class HudScore : IHudMember
    {
        int Score;
        
        public string StringValue { get; set; }

        public HudScore(int InitialValue)
        {
            Score = InitialValue;
            
            StringValue = "";
            CalculateValue();
        }
        public void AddValue(int value)
        {
            Score = Score + value;
            CalculateValue();
        }

        public void SetValue(int value)
        {
            Score = value;
            CalculateValue();
        }

       
        public void CalculateValue()
        {
            Score = World.Instance.Player.Score;
            StringValue = "";
            int ScoreCopy = Score;
            int Power = 100000;
            for (int i = 0; i < 6; i++)
            {
                int Digit = ScoreCopy / Power;
                if (Digit == 0)
                {
                    StringValue = StringValue + 0;
                }
                else
                {
                    StringValue = StringValue + Digit;
                }
                ScoreCopy = ScoreCopy - (Power * Digit);
                Power = (Power / 10);
            }
        }
    }
}
