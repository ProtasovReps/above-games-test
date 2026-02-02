using System.Collections.Generic;
using Interface;

namespace Popups
{
    public struct PopupSubscriber
    {
        public void Subscribe(
            PremiumPopup premiumPopup,
            DefaultPopup defaultPopup,
            IEnumerable<IImageBlock> imageBlocks,
            int everyPremiumBlockNumber)
        {
            int index = 1;

            foreach (IImageBlock block in imageBlocks)
            {
                if (index % everyPremiumBlockNumber == 0)
                {
                    premiumPopup.Add(block);
                }
                else
                {
                    defaultPopup.Add(block);
                }

                index++;
            }
        }
    }
}