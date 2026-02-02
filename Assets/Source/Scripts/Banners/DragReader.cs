using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Banners
{
    public class DragReader : MonoBehaviour, IBeginDragHandler, IEndDragHandler
    {
        public event Action<float> DragBegan;
        public event Action<float> DragEnded;
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            DragBegan?.Invoke(eventData.position.x);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            DragEnded?.Invoke(eventData.position.x);
        }
    }
}