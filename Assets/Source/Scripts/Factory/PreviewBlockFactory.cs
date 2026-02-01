using System;
using LevelPanel;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Factory
{
    public sealed class PreviewBlockFactory
    {
        private readonly LevelBlock _prefab;
        private readonly RectTransform _placeholder;
        
        public PreviewBlockFactory(LevelBlock prefab, RectTransform placeholder)
        {
            if (prefab == null)
            {
                throw new ArgumentNullException(nameof(prefab));
            }

            if (placeholder == null)
            {
                throw new ArgumentNullException(nameof(placeholder));
            }
            
            _prefab = prefab;
            _placeholder = placeholder;
        }

        public LevelBlock Produce()
        {
            return Object.Instantiate(_prefab, _placeholder);
        }
    }
}