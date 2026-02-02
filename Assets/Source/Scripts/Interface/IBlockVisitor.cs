using LevelPanel;

namespace Interface
{
    public interface IBlockVisitor
    {
        public void Visit(FreeLevelBlock freeBlock);

        public void Visit(PremiumLevelBlock premiumBlock);
    }
}