using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using LitMotion;
using UnityEngine;
using UnityEngine.UI;

namespace Banners
{
    [Serializable]
    public struct ScrollAnimation
    {
        [SerializeField] private float _duration;
        [SerializeField] private Ease _ease;
        
        public async UniTask AnimateScrollRect(
            float target,
            ScrollRect scrollRect,
            CancellationToken token)
        {
            float start = scrollRect.normalizedPosition.x;

            await LMotion.Create(start, target, _duration)
                .WithEase(_ease)
                .Bind(newPosition => scrollRect.normalizedPosition = new Vector2(newPosition, 0))
                .ToValueTask(CancelBehavior.Cancel, token);
        }
    }
}