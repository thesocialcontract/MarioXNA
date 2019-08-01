namespace Game1.Entities.Mario.States
{
    class LeftWinningSmallWarioState : WarioState
    {
        public LeftWinningSmallWarioState(Wario wario) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateLeftWinningSmallWarioSprite());
        }
        public override void RunRight()
        {
            Wario.MarioState = new RightWinningSmallWarioState(Wario);
        }
    }
}