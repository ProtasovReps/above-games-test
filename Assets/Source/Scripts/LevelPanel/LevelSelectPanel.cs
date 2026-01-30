using System;
using System.Collections.Generic;
using Extensions;
using Interface;
using UnityEngine;
using UnityEngine.UI;

namespace LevelPanel
{
    [RequireComponent(typeof(RectTransform))]
    public class LevelSelectPanel : MonoBehaviour, ILoadRequester<Sprite>
    {
        [SerializeField] [Min(1)] private float _entranceCheckOffsetFactor;
        [SerializeField] private ScrollRect _scrollRect;

        private VerticalEntranceDetector _entranceDetector;
        private Queue<LevelPreviewBlock> _bareBlocks;

        public event Action<ILoadPath<Sprite>> Requested;

        private void Start()
        {
            RectTransform rectTransform = GetComponent<RectTransform>();
            _entranceDetector = new VerticalEntranceDetector(rectTransform, _entranceCheckOffsetFactor);
        }

        private void OnDestroy()
        {
            _scrollRect.onValueChanged.RemoveListener(_ => CheckEntries());
        }

        public void Initialize(int levelCount)
        {
            _bareBlocks = new Queue<LevelPreviewBlock>(levelCount);

            _scrollRect.onValueChanged.AddListener(_ => CheckEntries());
        }

        public void Add(LevelPreviewBlock previewBlock)
        {
            if (previewBlock == null)
            {
                throw new ArgumentNullException(nameof(previewBlock));
            }

            _bareBlocks.Enqueue(previewBlock);
        }

        private void CheckEntries()
        {
            if (_bareBlocks.Count == 0)
            {
                return;
            }

            LevelPreviewBlock previewBlock = _bareBlocks.Peek();

            if (_entranceDetector.IsVerticallyInside(previewBlock.Position) == false)
            {
                return;
            }

            _bareBlocks.Dequeue();
            Requested?.Invoke(previewBlock);
        }
    }
}