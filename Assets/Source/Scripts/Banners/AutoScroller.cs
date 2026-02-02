using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Banners
{
    public class AutoScroller : MonoBehaviour
    {
        [SerializeField] private DragReader _dragReader;
        [SerializeField] private BannerCarousel _bannerCarousel;
        [SerializeField] private float _scrollInterval;
        [SerializeField, Range(-1, 1)] private float _dragDelta;

        private CancellationTokenSource _cancellationTokenSource;

        private void Start()
        {
            _dragReader.DragBegan += _ => Reset();
            _dragReader.DragEnded += _ => Restart();

            Restart();
        }

        private void OnDestroy()
        {
            Reset();
            _cancellationTokenSource?.Dispose();
        }

        private void Restart()
        {
            _cancellationTokenSource = new CancellationTokenSource();

            ScrollRepeatedly().Forget();
        }

        private void Reset()
        {
            _cancellationTokenSource?.Cancel();
        }

        private async UniTaskVoid ScrollRepeatedly()
        {
            while (_cancellationTokenSource.IsCancellationRequested == false)
            {
                await UniTask.WaitForSeconds(
                    _scrollInterval, cancellationToken: _cancellationTokenSource.Token, cancelImmediately: true);

                _bannerCarousel.Move(_dragDelta);
            }
        }
    }
}