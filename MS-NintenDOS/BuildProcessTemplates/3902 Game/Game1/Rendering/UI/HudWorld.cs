namespace Game1.Rendering.UI
{
    public class HudWorld : IHudMember
    {
        int World;
        int Level;
                
        public string StringValue { get; set; }

        public HudWorld(int InputWorld, int InputLevel)
        {
            World = InputWorld;
            Level = InputLevel;
            
            StringValue = "";
            CalculateValue();
        }
        public void AddValue(int value)
        {
            World = World + value;
            CalculateValue();
        }

        public void SetValue(int value)
        {
            int Digit = value / 10;
            int Digit2 = value - (Digit * 10);

            World = Digit;
            Level = Digit2;
            CalculateValue();
        }

        
        public void CalculateValue()
        {
            StringValue = "";
            StringValue = StringValue + World + " - " + Level;
            

        }
        

    }
}
