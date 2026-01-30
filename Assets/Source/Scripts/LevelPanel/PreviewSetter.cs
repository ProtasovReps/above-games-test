using System;
using Cysharp.Threading.Tasks;
using Factory;
using HTTPRequests;
using Interface;
using UnityEngine;

namespace LevelPanel
{
    public class PreviewSetter : IDisposable
    {
        private readonly SpriteFactory _spriteFactory;
        private readonly ImageUrlBuilder _urlBuilder;
        private readonly ILoadRequester<Sprite> _loadRequester;
        private readonly IHttpLoader<Texture2D> _loader;

        private int _imageNumber = 1;
        
        public PreviewSetter(
            IHttpLoader<Texture2D> loader,
            SpriteFactory factory,
            ILoadRequester<Sprite> requester,
            ImageUrlBuilder urlBuilder)
        {
            _loader = loader;
            _spriteFactory = factory;
            _loadRequester = requester;
            _urlBuilder = urlBuilder;
            
            _loadRequester.Requested += OnRequested;
        }

        public void Dispose()
        {
            _loader?.Dispose();
            _loadRequester.Requested -= OnRequested;
        }

        private void OnRequested(ILoadPath<Sprite> loadPath)
        {
            File file = new (_imageNumber++);
            
            _urlBuilder.SetFile(ref file);
            
            string url = _urlBuilder.Get();
            
            LoadPreview(loadPath, url).Forget();
        }

        private async UniTaskVoid LoadPreview(ILoadPath<Sprite> loadPath, string url) // cancellationToken
        {
            Texture2D texture = await _loader.Load(url);
            Sprite sprite = _spriteFactory.Produce(texture);
            
            loadPath.Set(sprite);
        }
    }
}