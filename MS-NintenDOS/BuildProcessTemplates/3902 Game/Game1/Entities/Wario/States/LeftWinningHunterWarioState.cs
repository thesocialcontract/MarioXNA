namespace Game1.Entities.Mario.States
{
    class LeftWinningHunterWarioState : WarioState
    {
        public LeftWinningHunterWarioState(Wario wario) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateLeftWinningHunterWarioSprite());
        }
        public override void RunRight()
        {
            Wario.MarioState = new RightWinningHunterWarioState(Wario);
        }
    }
}
