using Interface;
using UnityEngine;
using UnityEngine.UI;

namespace Popups
{
    public class DefaultPopup : Popup
    {
        [SerializeField] private Image _preview;
        
        protected override void OnImageBlockClicked(IImageBlock imageBlock)
        {
            if (imageBlock.TryGet(out Sprite sprite) == false)
            {
                return;
            }

            _preview.sprite = sprite;
            base.OnImageBlockClicked(imageBlock);
        }
    }
}