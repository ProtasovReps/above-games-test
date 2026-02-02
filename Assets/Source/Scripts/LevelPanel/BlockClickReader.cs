using System;
using Interface;
using UnityEngine;
using UnityEngine.UI;

namespace LevelPanel
{
    public sealed class BlockClickReader : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private LevelBlock _levelBlock;
        
        public event Action<IImageBlock> Clicked;
        
        private void Awake()
        {
            _button.onClick.AddListener(InvokeClicked);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(InvokeClicked);
        }
        
        private void InvokeClicked()
        {
            Clicked?.Invoke(_levelBlock);
        }
    }
}