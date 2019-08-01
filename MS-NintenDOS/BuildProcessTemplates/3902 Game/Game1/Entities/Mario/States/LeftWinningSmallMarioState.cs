namespace Game1.Entities.Mario.States
{
    class LeftWinningSmallMarioState : MarioState
    {
        public LeftWinningSmallMarioState(Mario mario) : base(mario)
        {
            base.SetSprite(MarioSpriteFactory.Instance.CreateLeftWinningSmallMarioSprite());
        }
        public override void RunRight()
        {
            Mario.MarioState = new RightWinningSmallMarioState(Mario);
        }
    }
}