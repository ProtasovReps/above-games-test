using System;
using System.Collections.Generic;
using System.Linq;
using Banners;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Factory
{
    public class BannerFactory
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

        public IEnumerable<Banner> Produce(Banner[] prefabs)
        {
            List<Banner> banners = new();

            banners.Add(Instantiate(prefabs.Last()));

            for (int i = 0; i < prefabs.Length; i++)
            {
                banners.Add(Instantiate(prefabs[i]));
            }
            
            banners.Add(Instantiate(prefabs.First()));
            
            return banners;
        }

        private Banner Instantiate(Banner prefab)
        {
            return Object.Instantiate(prefab, _placeHolder);
        }
    }
}