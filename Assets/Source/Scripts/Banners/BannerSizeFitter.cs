using UnityEngine;

namespace Banners
{
    public class BannerSizeFitter
    {
        public void Fit(RectTransform content)
        {
            int count = 4;
            int half = 2;
            float halfContentSizePadding = content.rect.width * count / half;
            
            content.offsetMin = new Vector2(-halfContentSizePadding, content.offsetMin.y);
            content.offsetMax = new Vector2(halfContentSizePadding, content.offsetMax.y);
        }
    }
}