namespace Game1.Entities.Mario.States
{
    class LeftWinningFireMarioState : MarioState
    {
        public LeftWinningFireMarioState(Mario mario) : base(mario)
        {
            base.SetSprite(MarioSpriteFactory.Instance.CreateLeftWinningFireMarioSprite());
        }
        public override void RunRight()
        {
            Mario.MarioState = new RightWinningFireMarioState(Mario);

        }
    }
}