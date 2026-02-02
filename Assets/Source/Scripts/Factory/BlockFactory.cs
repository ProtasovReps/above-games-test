using System.Collections.Generic;
using LevelPanel;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Factory
{
    public sealed class BlockFactory
    {
        private readonly RectTransform _placeholder;
        private readonly FreeLevelBlock _defaultPrefab;
        private readonly PremiumLevelBlock _premiumPrefab;
        
        public BlockFactory(FreeLevelBlock defaultPrefab, PremiumLevelBlock premiumPrefab, RectTransform placeholder)
        {
            _defaultPrefab = defaultPrefab;
            _premiumPrefab = premiumPrefab;
            _placeholder = placeholder;
        }

        public List<LevelBlock> Produce(int count, int everyPremiumNumber)
        {
            List<LevelBlock> blocks = new ();
            int startIndex = 1;
            
            for (int i = startIndex; i <= count; i++)
            {
                LevelBlock block;
                
                if (i % everyPremiumNumber == 0)
                {
                    block = Instantiate(_premiumPrefab);
                }
                else
                {
                    block = Instantiate(_defaultPrefab);
                }
                
                blocks.Add(block);
            }

            return blocks;
        }

        private LevelBlock Instantiate(LevelBlock prefab)
        {
            return Object.Instantiate(prefab, _placeholder);
        }
    }
}