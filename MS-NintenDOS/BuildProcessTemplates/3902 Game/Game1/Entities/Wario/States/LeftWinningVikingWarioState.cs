namespace Game1.Entities.Mario.States
{
    class LeftWinningVikingWarioState : WarioState
    {
        public LeftWinningVikingWarioState(Wario wario) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateLeftWinningVikingWarioSprite());
        }
        public override void RunRight()
        {
            Wario.MarioState = new RightWinningVikingWarioState(Wario);

        }
    }
}