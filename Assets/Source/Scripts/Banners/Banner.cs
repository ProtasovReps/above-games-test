using UnityEngine;

namespace Banners
{
    public class Banner : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;

        public RectTransform Transform => _rectTransform;
    }
}