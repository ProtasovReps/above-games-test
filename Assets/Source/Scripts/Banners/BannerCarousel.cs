using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Banners
{
    public class BannerCarousel : MonoBehaviour, IBeginDragHandler, IEndDragHandler
    {
        private const int FirstBannerIndex = 1;
        private const int Step = 1;

        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField, Range(0.1f, 1f)] private float _dragThreshold;

        private Banner[] _banners;
        private float _startDragPosition;
        private int _currentIndex;

        public void OnBeginDrag(PointerEventData eventData) // все баннеры кроме текущего выключены, включать тут
        {
            _startDragPosition = eventData.position.x;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            float positionDelta = (eventData.position.x - _startDragPosition) / Screen.width;

            if (Mathf.Abs(positionDelta) > _dragThreshold)
            {
                ShowNext(Mathf.Sign(positionDelta));
            }
            else
            {
                _scrollRect.normalizedPosition = GetNormalizedPosition(_currentIndex);
            }
        }

        public void Initialize(IEnumerable<Banner> banners)
        {
            _banners = banners.ToArray();
            _currentIndex = FirstBannerIndex;
            _scrollRect.normalizedPosition = GetNormalizedPosition(_currentIndex);
        }

        private void ShowNext(float sign) // также нужно обыграть первый и последний, чтобы они тэпали
        {
            int next;

            if (sign < 0)
            {
                next = (_currentIndex + Step) % _banners.Length;
            }
            else
            {
                next = (_currentIndex - Step + _banners.Length) % _banners.Length;
            }

            _scrollRect.normalizedPosition = GetNormalizedPosition(next);
            _currentIndex = next;
        }

        private Vector2 GetNormalizedPosition(int index)
        {
            float oneMinus = 1;
            float normalizedPositon = index / (_banners.Length - oneMinus);

            return new Vector2(normalizedPositon, 0f);
        }
    }
}