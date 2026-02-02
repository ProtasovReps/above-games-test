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
            if (imageBlock.TryGet(out Image image) == false)
            {
                return;
            }

            _preview.sprite = image.sprite;
            base.OnImageBlockClicked(imageBlock);
        }
    }
}