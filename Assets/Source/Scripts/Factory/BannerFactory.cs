using System;
using Banners;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Factory
{
    public sealed class BannerFactory
    {
        private readonly RectTransform _placeHolder;

        public BannerFactory(RectTransform placeHolder)
        {
            if (placeHolder == null)
            {
                throw new ArgumentNullException(nameof(placeHolder));
            }

            _placeHolder = placeHolder;
        }

        public void Produce(Banner[] prefabs)
        {
            for (int i = 0; i < prefabs.Length; i++)
            {
                Instantiate(prefabs[i]);
            }
        }

        private void Instantiate(Banner prefab)
        {
            Object.Instantiate(prefab, _placeHolder);
        }
    }
}