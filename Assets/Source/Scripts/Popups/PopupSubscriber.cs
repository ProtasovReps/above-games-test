using System.Collections.Generic;
using Interface;
using LevelPanel;

namespace Popups
{
    public class PopupSubscriber : IBlockVisitor
    {
        private readonly DefaultPopup _defaultPopup;
        private readonly PremiumPopup _premiumPopup;

        public PopupSubscriber(DefaultPopup defaultPopup, PremiumPopup premiumPopup)
        {
            _defaultPopup = defaultPopup;
            _premiumPopup = premiumPopup;
        }

        public void VisitAll(IEnumerable<LevelBlock> levelBlocks)
        {
            foreach (LevelBlock block in levelBlocks)
            {
                block.Accept(this);
            }
        }
        
        public void Visit(FreeLevelBlock freeBlock)
        {
            _defaultPopup.Add(GetClickReader(freeBlock));
        }
        
        public void Visit(PremiumLevelBlock premiumBlock)
        {
            _premiumPopup.Add(GetClickReader(premiumBlock));
        }

        private BlockClickReader GetClickReader(LevelBlock block)
        {
            return block.GetComponent<BlockClickReader>();
        }
    }
}