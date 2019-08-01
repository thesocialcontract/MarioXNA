namespace Game1.Rendering.UI
{
    public interface IHudMember
    {
        string StringValue { get; set; }

        void AddValue(int value);

        void SetValue(int value);

        void CalculateValue();
        


    }
}
