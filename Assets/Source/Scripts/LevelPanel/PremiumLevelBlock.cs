using Interface;

namespace LevelPanel
{
    public sealed class PremiumLevelBlock : LevelBlock
    {
        public override void Accept(IBlockVisitor blockVisitor)
        {
            blockVisitor.Visit(this);
        }
    }
}