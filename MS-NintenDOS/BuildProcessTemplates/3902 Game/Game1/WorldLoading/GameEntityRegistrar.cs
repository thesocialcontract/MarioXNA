namespace Game1.WorldLoading
{
    public class GameEntityRegistrar
    {
        public string EntityType { get; set; }
        public int WorldPosX { get; set; }
        public int WorldPosY { get; set; }
        public bool HasDynamicCollider { get; set; }
        public int BlockLength { get; set; }
        public int BlockHeight { get; set; }
        public BlockContentRegistrar BlockContent { get; set; }
        public int? WorldPosXBlock { get; set; }
        public int? WorldPosYBlock { get; set; }
        public int WarpID { get; set; }
        public int WarpTo { get; set; }
    }
}
