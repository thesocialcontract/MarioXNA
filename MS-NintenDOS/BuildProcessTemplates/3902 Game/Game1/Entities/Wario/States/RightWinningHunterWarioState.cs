namespace Game1.Entities.Mario.States
{
    class RightWinningHunterWarioState : WarioState
    {
        public RightWinningHunterWarioState(Wario wario) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateRightWinningHunterWarioSprite());
        }
        public override void RunRight()
        {
            Wario.MarioState = new RightWalkingHunterWarioState(Wario);

        }
    }
}