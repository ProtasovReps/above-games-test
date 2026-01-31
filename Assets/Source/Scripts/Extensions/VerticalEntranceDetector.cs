using UnityEngine;

namespace Extensions
{
    public class VerticalEntranceDetector
    {
        private readonly float _minVerticalPosition;
        private readonly RectTransform _transform;
        
        public VerticalEntranceDetector(RectTransform rectTransform, float offsetFactor)
        {
            int devider = 2;
            float devidedHeight = rectTransform.rect.height / devider;

            _minVerticalPosition = rectTransform.anchoredPosition.y - devidedHeight * offsetFactor;
            _transform = rectTransform;
        }

        public bool IsVerticallyInside(Vector3 position)
        {
            Vector3 insidePosition = _transform.InverseTransformPoint(position);
            return insidePosition.y > _minVerticalPosition;
        }
    }
}