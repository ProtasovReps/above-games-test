using System;
using LevelPanel;
using UnityEngine.UI;

namespace Interface
{
    public interface IImageBlock
    {
        public event Action<LevelBlock> Clicked;
        
        public bool TryGet(out Image image);
    }
}