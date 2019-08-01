namespace Game1.Entities.Blocks
{
    public interface IContainableBlock : IBlock
    {
        BlockContent Content { get; set; }
    }
}
