using System;
using LevelPanel;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Factory
{
    public class PreviewBlockFactory
    {
        private readonly LevelPreviewBlock _prefab;
        private readonly RectTransform _placeholder;
        
        public PreviewBlockFactory(LevelPreviewBlock prefab, RectTransform placeholder)
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

        public LevelPreviewBlock Produce()
        {
            return Object.Instantiate(_prefab, _placeholder);
        }
    }
}