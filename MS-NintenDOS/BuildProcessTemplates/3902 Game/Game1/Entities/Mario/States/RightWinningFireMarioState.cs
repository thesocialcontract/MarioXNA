namespace Game1.Entities.Mario.States
{
    class RightWinningFireMarioState : MarioState
    {
        public RightWinningFireMarioState(Mario mario) : base(mario)
        {
            base.SetSprite(MarioSpriteFactory.Instance.CreateRightWinningFireMarioSprite());
        }
        public override void RunRight()
        {
            Mario.MarioState = new RightRunningFireMarioState(Mario);

        }
    }
}