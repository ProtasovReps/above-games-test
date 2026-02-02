using Interface;

namespace LevelPanel
{
    public sealed class FreeLevelBlock : LevelBlock
    {
        public override void Accept(IBlockVisitor blockVisitor)
        {
            blockVisitor.Visit(this);
        }
    }
}