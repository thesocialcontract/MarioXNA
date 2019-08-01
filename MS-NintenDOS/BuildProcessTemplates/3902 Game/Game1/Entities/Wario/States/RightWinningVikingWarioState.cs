namespace Game1.Entities.Mario.States
{
    class RightWinningVikingWarioState : WarioState
    {
        public RightWinningVikingWarioState(Wario wario) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateRightWinningVikingWarioSprite());
        }
        public override void RunRight()
        {
            Wario.MarioState = new RightWalkingVikingWarioState(Wario);

        }
    }
}