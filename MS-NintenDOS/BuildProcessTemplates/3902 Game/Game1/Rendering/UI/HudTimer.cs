using Game1.WorldLoading;

namespace Game1.Rendering.UI
{
    public class HudTimer : IHudMember
    {
        int Time;
        int DelayTime;
        int DelayTimeAmount;
        
        public string StringValue { get; set; }

        public HudTimer()
        {
            int defaultTime = 300;
            Time = defaultTime;
            
            DelayTimeAmount = 60;
            DelayTime = DelayTimeAmount;
            StringValue = "";
            CalculateValue();

        }
        public void AddValue(int value)
        {
            Time = Time + value;
            CalculateValue();
        }

        public void SetValue(int value)
        {
            Time = value;
            CalculateValue();
        }

        
        public void CalculateValue()
        {
            Time = (int)World.Instance.State.SecondsLeft;
            bool ChangeTime = false;
            DelayTime--;

            if (DelayTime == 0)
            {
                DelayTime = DelayTimeAmount;
                Time--;
                ChangeTime = true;
            }
            if(Time < 0)
            {
                Time = 0;
            }
            if (ChangeTime)
            {
                StringValue = "";
                int TimeCopy = Time;
                int Power = 100;
                for (int i = 0; i < 3; i++)
                {
                    int Digit = TimeCopy / Power;
                    if (Digit == 0)
                    {
                        StringValue = StringValue + 0;
                    }
                    else
                    {
                        StringValue = StringValue + Digit;
                    }
                    TimeCopy = TimeCopy - (Power * Digit);
                    Power = (Power / 10);
                }
            }
            
        }
        
    }
}
