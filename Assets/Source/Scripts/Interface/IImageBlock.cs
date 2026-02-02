using UnityEngine;

namespace Interface
{
    public interface IImageBlock
    {
        public bool TryGet(out Sprite image);
    }
}