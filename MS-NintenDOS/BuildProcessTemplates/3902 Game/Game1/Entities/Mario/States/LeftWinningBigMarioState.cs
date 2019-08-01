namespace Game1.Entities.Mario.States
{
    class LeftWinningBigMarioState : MarioState
    {
        public LeftWinningBigMarioState(Mario mario) : base(mario)
        {
            base.SetSprite(MarioSpriteFactory.Instance.CreateLeftWinningBigMarioSprite());
        }
        public override void RunRight()
        {
            Mario.MarioState = new RightWinningBigMarioState(Mario);
        }
    }
}
