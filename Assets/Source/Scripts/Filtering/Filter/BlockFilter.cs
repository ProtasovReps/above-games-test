using System.Collections.Generic;
using LevelPanel;
using UnityEngine;

namespace Filtering.Filter
{
    public abstract class BlockFilter : MonoBehaviour
    {
        private const int StartOrdinalNumber = 1;

        public void Sort(IEnumerable<LevelBlock> blocks)
        {
            int ordinalNumber = StartOrdinalNumber;

            foreach (LevelBlock block in blocks)
            {
                bool isValid = IsValid(ordinalNumber);
                
                block.gameObject.SetActive(isValid);

                ordinalNumber++;
            }            
        }

        protected abstract bool IsValid(int ordinalNumber);
    }
}