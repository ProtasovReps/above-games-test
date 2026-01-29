using Interface;
using Loader;
using Source.Scripts;
using UnityEngine;
using UnityEngine.UI;
using UrlParts;
using UrlParts.Formats;
using UrlParts.Urls;

namespace Extensions
{
    public class CompositeRoot : MonoBehaviour
    {
        // [SerializeField] private LevelPreviewPanel _levelPreviewPanel;
        [SerializeField] private Image _image;

        private void Awake()
        {
            IHttpLoader<Texture2D> httpLoader = new ImageLoader();
            UrlBuilder builder = new();

            File file = new File(2);

            builder
                .SetUrl(new TextureUrl())
                .SetFile(ref file)
                .SetFormat(new Jpg());

            StartCoroutine(httpLoader.Load(builder.Build(), ShowImage));
        }

        private void ShowImage(Texture2D texture)
        {
            Sprite sprite = Sprite.Create(
                texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);

            _image.sprite = sprite;
        }
    }
}