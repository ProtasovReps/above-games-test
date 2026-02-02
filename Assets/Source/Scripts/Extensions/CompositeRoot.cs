using System;
using System.Collections.Generic;
using System.Linq;
using Banners;
using Factory;
using Filtering;
using HTTPRequests;
using LevelPanel;
using UnityEngine;

namespace Extensions
{
    public sealed class CompositeRoot : MonoBehaviour
    {
        private readonly Disposer _disposer = new ();
        
        [Header("Level Preview")]
        [SerializeField] private RectTransform _previewBlockPlaceholder;
        [SerializeField] private LevelBlock _prefab;
        [SerializeField] private LevelSelectPanel _levelSelectPanel;
        [SerializeField] [Min(1)] private int _levelCount;
        
        [Header("Filter")]
        [SerializeField] private FilterPanel _filterPanel;
        
        [Header("Banner Carousel")]
        [SerializeField] private BannerCarousel _bannerCarousel;
        [SerializeField] private Banner[] _banners;
        [SerializeField] private RectTransform _bannersPlaceHolder;
        
        private void Awake()
        {
            PreviewBlockFactory blockFactory = new(_prefab, _previewBlockPlaceholder);
            LevelBlock[] blocks = new LevelBlock[_levelCount];

            for (int i = 0; i < _levelCount; i++)
            {
                blocks[i] = blockFactory.Produce();
            }
            
            InstallLevelSelectPanel(blocks);
            InstallFilter(blocks);
        }

        private void Start()
        {
            InstallBannerCarousel();
        }

        private void OnDestroy()
        {
            _disposer.Dispose();
        }

        private void InstallBannerCarousel()
        {
            BannerFactory bannerFactory = new (_bannersPlaceHolder);
            new BannerSizeFitter().Fit(_bannersPlaceHolder, _banners.Length);
            
            bannerFactory.Produce(_banners);
            _bannerCarousel.Initialize(_banners.Length);
            _disposer.Add(_bannerCarousel);
        }
        
        private void InstallLevelSelectPanel(IEnumerable<LevelBlock> blocks)
        {
            SpriteFactory spriteFactory = new();
            ImageUrlBuilder urlBuilder = new();
            TextureLoader textureLoader = new();
            PreviewSetter previewSetter = new(textureLoader, spriteFactory, _levelSelectPanel, urlBuilder);

            _levelSelectPanel.Initialize(blocks);
            _disposer.Add(textureLoader);
            _disposer.Add(previewSetter);
            _disposer.Add(_levelSelectPanel);
        }

        private void InstallFilter(IEnumerable<LevelBlock> blocks)
        {
            _filterPanel.Initialize(blocks);
        }
    }
}