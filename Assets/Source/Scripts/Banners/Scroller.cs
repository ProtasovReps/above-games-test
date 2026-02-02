using UnityEngine;

namespace Banners
{
    public class Scroller : MonoBehaviour
    {
        [SerializeField] private BannerCarousel _bannerCarousel;
        [SerializeField] private DragReader _dragReader;
        
        private float _startDragPosition;

        private void Start()
        {
            _dragReader.DragBegan += OnDragBegan;
            _dragReader.DragEnded += OnDragEnded;
        }

        private void OnDestroy()
        {
            _dragReader.DragBegan -= OnDragBegan;
            _dragReader.DragEnded -= OnDragEnded;
        }

        private void OnDragBegan(float position)
        {
            _startDragPosition = position;
        }

        private void OnDragEnded(float position)
        {
            float positionDelta = (position - _startDragPosition) / Screen.width;

            _bannerCarousel.Move(positionDelta);
        }
    }
}