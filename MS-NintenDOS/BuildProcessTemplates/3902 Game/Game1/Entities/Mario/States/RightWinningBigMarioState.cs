namespace Game1.Entities.Mario.States
{
    class RightWinningBigMarioState : MarioState
    {
        public RightWinningBigMarioState(Mario mario) : base(mario)
        {
            base.SetSprite(MarioSpriteFactory.Instance.CreateRightWinningBigMarioSprite());
        }
        public override void RunRight()
        {
            Mario.MarioState = new RightRunningBigMarioState(Mario);

        }
    }
}