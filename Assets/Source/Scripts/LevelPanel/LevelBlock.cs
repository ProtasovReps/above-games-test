using Interface;
using UnityEngine;
using UnityEngine.UI;

namespace LevelPanel
{
    [RequireComponent(typeof(BlockClickReader))]
    public abstract class LevelBlock : MonoBehaviour, ILoadPath<Sprite>, IImageBlock
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Image _image;

        private bool _isSetted;
        
        public Vector3 WorldPosition => _rectTransform.position;

        public void Set(Sprite sprite)
        {
            _image.sprite = sprite;
            _isSetted = true;
        }

        public bool TryGet(out Sprite image)
        {
            image = _image.sprite;
            return _isSetted;
        }

        public abstract void Accept(IBlockVisitor blockVisitor);
    }
}