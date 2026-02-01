using Interface;
using UnityEngine;
using UnityEngine.UI;

namespace LevelPanel
{
    public class LevelBlock : MonoBehaviour, ILoadPath<Sprite>
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Image _image;
        
        public Vector3 WorldPosition => _rectTransform.position;
        
        public void Set(Sprite sprite)
        {
            _image.sprite = sprite;
        }
    }
}