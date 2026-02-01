using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Extensions;
using Interface;
using UnityEngine;

namespace LevelPanel
{
    public class LevelSelectPanel : MonoBehaviour, ILoadRequester<Sprite>, IDisposable
    {
        private const int OneMinus = 1;

        private readonly CancellationTokenSource _cancellationTokenSource = new();

        [SerializeField] [Min(1)] private float _entranceOffsetFactor;
        [SerializeField] private float _entranceCheckInterval;

        private VerticalEntranceDetector _entranceDetector;
        private List<LevelBlock> _bareBlocks;

        public event Action<ILoadPath<Sprite>> Requested;

        private void Start()
        {
            RectTransform rectTransform = GetComponent<RectTransform>();

            _entranceDetector = new VerticalEntranceDetector(rectTransform, _entranceOffsetFactor);

            CheckEntrance(_cancellationTokenSource.Token).Forget();
        }

        public void Dispose()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
        }

        public void Initialize(IEnumerable<LevelBlock> levelPreviewBlocks)
        {
            _bareBlocks = new List<LevelBlock>(levelPreviewBlocks);
        }

        private async UniTaskVoid CheckEntrance(CancellationToken token)
        {
            await UniTask.NextFrame(token, true);

            while (_bareBlocks.Count != 0 && token.IsCancellationRequested == false)
            {
                for (int i = _bareBlocks.Count - OneMinus; i >= 0; i--)
                {
                    LevelBlock block = _bareBlocks[i];

                    if (_entranceDetector.IsVerticallyInside(block.WorldPosition) == false)
                    {
                        continue;
                    }

                    _bareBlocks.RemoveAt(i);
                    Requested?.Invoke(block);

                }

                await UniTask.WaitForSeconds(
                    _entranceCheckInterval, cancellationToken: token, cancelImmediately: true);
            }
        }
    }
}