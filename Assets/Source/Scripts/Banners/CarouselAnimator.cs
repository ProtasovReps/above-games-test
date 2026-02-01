using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Banners
{
    [Serializable]
    public class CarouselAnimator
    {
        // [SerializeField] private AnimationCurve _curve;
        [SerializeField] private float _duration;
        
        public async UniTaskVoid Animate(RectTransform animatable, Vector2 targetPosition, CancellationToken token)
        {
            float elapsedTime = 0f;
            
            while (elapsedTime < _duration && token.IsCancellationRequested == false)
            {
                Vector2 newPosition = Vector2.Lerp(animatable.anchoredPosition, targetPosition, elapsedTime / _duration);
                
                animatable.anchoredPosition = newPosition;

                elapsedTime += Time.deltaTime;
                await UniTask.Yield(token, true);
            } 
        }        
    }
}