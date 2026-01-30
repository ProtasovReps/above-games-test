using System;
using System.Collections.Generic;
using Extensions;
using Interface;
using UnityEngine;
using UnityEngine.UI;

namespace LevelPanel
{
    public class LevelSelectPanel : MonoBehaviour, ILoadRequester<Sprite>
    {
        [SerializeField] [Min(1)] private float _entranceCheckOffsetFactor;
        [SerializeField] [Min(1)] private int _startCount;
        [SerializeField] private ScrollRect _scrollRect;
        
        private VerticalEntranceDetector _entranceDetector;
        private Queue<LevelPreviewBlock> _bareBlocks;

        public event Action<ILoadPath<Sprite>> Requested;

        private void Start()
        {
            RectTransform rectTransform = _scrollRect.transform as RectTransform;
            
            _entranceDetector = new VerticalEntranceDetector(rectTransform, _entranceCheckOffsetFactor);
            
            for (int i = 0; i < _startCount; i++)
            {
                CheckEntries();
            }
        }

        private void OnDestroy()
        {
            _scrollRect.onValueChanged.RemoveListener(_ => CheckEntries());
        }

        public void Initialize(IEnumerable<LevelPreviewBlock> levelPreviewBlocks)
        {
            _bareBlocks = new Queue<LevelPreviewBlock>(levelPreviewBlocks);
            
            _scrollRect.onValueChanged.AddListener(_ => CheckEntries());
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