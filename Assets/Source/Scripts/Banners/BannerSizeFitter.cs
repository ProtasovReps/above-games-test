using UnityEngine;

namespace Banners
{
    public struct BannerSizeFitter
    {
        public void Fit(RectTransform content, int bannersCount)
        {
            int half = 2;
            int oneMinus = 1;
            float halfContentSizePadding = content.rect.width * (bannersCount - oneMinus) / half;
            
            content.offsetMin = new Vector2(-halfContentSizePadding, content.offsetMin.y);
            content.offsetMax = new Vector2(halfContentSizePadding, content.offsetMax.y);
        }
    }
}