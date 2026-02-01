using UnityEngine;

namespace Factory
{
    public sealed class SpriteFactory
    {
        public Sprite Produce(Texture2D texture)
        {
            return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
    }
}