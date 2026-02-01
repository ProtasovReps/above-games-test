using System;
using Banners;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Factory
{
    public sealed class BannerFactory
    {
        private readonly RectTransform _placeHolder;

        private int _count;
        
        public BannerFactory(RectTransform placeHolder)
        {
            if (placeHolder == null)
            {
                throw new ArgumentNullException(nameof(placeHolder));
            }

            _placeHolder = placeHolder;
        }

        public int Produce(Banner[] prefabs)
        {
            for (int i = 0; i < prefabs.Length; i++)
            {
                Instantiate(prefabs[i]);
            }
            
            return _count;
        }

        private void Instantiate(Banner prefab)
        {
            _count++;
            Object.Instantiate(prefab, _placeHolder);
        }
    }
}