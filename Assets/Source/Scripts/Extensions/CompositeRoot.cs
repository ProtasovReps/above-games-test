using Factory;
using HTTPRequests;
using LevelPanel;
using Loader;
using UnityEngine;

namespace Extensions
{
    public class CompositeRoot : MonoBehaviour
    {
        [SerializeField] private RectTransform _previewBlockPlaceholder;
        [SerializeField] private LevelPreviewBlock _prefab;
        [SerializeField] private LevelSelectPanel _levelSelectPanel;
        [SerializeField] [Min(1)] private int _levelCount;

        private void Awake()
        {
            PreviewBlockFactory blockFactory = new (_prefab, _previewBlockPlaceholder);
            SpriteFactory spriteFactory = new ();
            ImageUrlBuilder urlBuilder = new ();
            TextureLoader textureLoader = new ();
            PreviewSetter previewSetter = new (textureLoader, spriteFactory, _levelSelectPanel, urlBuilder);
            
            _levelSelectPanel.Initialize(_levelCount);

            for (int i = 0; i < _levelCount; i++)
            {
                LevelPreviewBlock newBlock = blockFactory.Produce();
                
                _levelSelectPanel.Add(newBlock);
            }
        }
    }
}