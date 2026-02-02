using System;
using Interface;
using UnityEngine;
using UnityEngine.UI;

namespace LevelPanel
{
    public sealed class LevelBlock : MonoBehaviour, ILoadPath<Sprite>, IImageBlock
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Image _image;
        [SerializeField] private Button _button;

        private bool _isSetted;
        
        public event Action<LevelBlock> Clicked;
        
        public Vector3 WorldPosition => _rectTransform.position;

        private void Awake()
        {
            _button.onClick.AddListener(InvokeClicked);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(InvokeClicked);
        }

        public void Set(Sprite sprite)
        {
            _image.sprite = sprite;
            _isSetted = true;
        }

        public bool TryGet(out Image image)
        {
            image = _image;
            return _isSetted;
        }

        private void InvokeClicked()
        {
            Clicked?.Invoke(this);
        }
    }
}