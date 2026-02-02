using System;
using UnityEngine;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;

namespace Banners
{
    public class BannerCarousel : MonoBehaviour, IDisposable
    {
        private const int Step = 1;

        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private ScrollAnimation _scrollAnimation;
        [SerializeField, Range(0.1f, 1f)] private float _dragThreshold;

        private int _bannersCount;
        private int _currentIndex;
        private CancellationTokenSource _cancellationTokenSource;

        public void Dispose()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
        }
        
        public void Initialize(int bannerCount)
        {
            _bannersCount = bannerCount;

            float newPosition = GetNormalizedPosition(_currentIndex);

            _scrollRect.normalizedPosition = new Vector2(newPosition, 0f);
        }

        public void Move(float dragDelta)
        {
            if (Mathf.Abs(dragDelta) > _dragThreshold)
            {
                ShowNext(Mathf.Sign(dragDelta));
            }
            else
            {
                ShowCurrent();
            }
        }

        private void ShowNext(float sign)
        {
            int next;

            if (sign < 0)
            {
                next = (_currentIndex + Step) % _bannersCount;
            }
            else
            {
                next = (_currentIndex - Step + _bannersCount) % _bannersCount;
            }

            float newPosition = GetNormalizedPosition(next);

            Animate(newPosition).Forget();
            _currentIndex = next;
        }

        private void ShowCurrent()
        {
            float newPosition = GetNormalizedPosition(_currentIndex);

            Animate(newPosition).Forget();
        }

        private float GetNormalizedPosition(int index)
        {
            float oneMinus = 1;
            float normalizedPositon = index / (_bannersCount - oneMinus);

            return normalizedPositon;
        }

        private async UniTask Animate(float newPosition)
        {
            if (_cancellationTokenSource != null)
            {
                return;
            }

            _scrollRect.horizontal = false;
            _cancellationTokenSource = new CancellationTokenSource();
            await _scrollAnimation.AnimateScrollRect(newPosition, _scrollRect, _cancellationTokenSource.Token);
            _cancellationTokenSource = null;
            _scrollRect.horizontal = true;
        }
    }
}