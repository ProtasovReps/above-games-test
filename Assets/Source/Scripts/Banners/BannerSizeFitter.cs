using UnityEngine;

namespace Banners
{
    public struct BannerSizeFitter
    {
        public void Fit(RectTransform content, int bannersCount)
        {
            int oneMinus = 1;
            
            content.sizeDelta = new Vector2(content.rect.width * (bannersCount - oneMinus), content.sizeDelta.y);
        }
    }
}