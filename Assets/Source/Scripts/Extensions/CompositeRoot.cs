using System.Collections.Generic;
using Banners;
using Factory;
using Filtering;
using HTTPRequests;
using Interface;
using LevelPanel;
using Popups;
using UnityEngine;

namespace Extensions
{
    public sealed class CompositeRoot : MonoBehaviour
    {
        private readonly Disposer _disposer = new();

        [Header("Level Preview")]
        [SerializeField] private RectTransform _previewBlockPlaceholder;
        [SerializeField] private FreeLevelBlock _freePrefab;
        [SerializeField] private PremiumLevelBlock _premiumPrefab;
        [SerializeField] private LevelSelectPanel _levelSelectPanel;
        [SerializeField] [Min(1)] private int _levelCount;

        [Header("Filter")] 
        [SerializeField] private FilterPanel _filterPanel;

        [Header("Banner Carousel")] 
        [SerializeField] private BannerCarousel _bannerCarousel;
        [SerializeField] private Banner[] _banners;
        [SerializeField] private RectTransform _bannersPlaceHolder;

        [Header("Popups")] 
        [SerializeField] private PremiumPopup _premiumPopup;
        [SerializeField] private DefaultPopup _defaultPopup;
        [SerializeField] private int _everyPremiumBlockNumber;

        private void Awake()
        {
            BlockFactory blockFactory = new (_freePrefab, _premiumPrefab, _previewBlockPlaceholder);
            List<LevelBlock> blocks = blockFactory.Produce(_levelCount, _everyPremiumBlockNumber);

            InstallLevelSelectPanel(blocks);
            InstallFilter(blocks);
            InstallPopups(blocks);
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
            BannerFactory bannerFactory = new(_bannersPlaceHolder);
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

        private void InstallPopups(IEnumerable<LevelBlock> blocks)
        {
            _defaultPopup.Initialize();
            _premiumPopup.Initialize();
            
            PopupSubscriber subscriber = new(_defaultPopup, _premiumPopup);
            
            subscriber.VisitAll(blocks);
        }
    }
}