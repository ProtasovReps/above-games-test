using LitMotion;
using LitMotion.Extensions;
using UnityEngine;

namespace Extensions
{
    public class SplashScreenAnimation : MonoBehaviour
    {
        [SerializeField] private Canvas _splashScreenCanvas;
        [SerializeField] private RectTransform _splash;
        [SerializeField] private float _duration;
        [SerializeField] private float _delay;
        [SerializeField] private Ease _ease;
        
        private void Start()
        {
            LMotion.Create(_splash.localScale, new Vector3(0, 0, 0), _duration)
                .WithDelay(_delay)
                .WithEase(_ease)
                .WithOnComplete(() => _splashScreenCanvas.gameObject.SetActive(false))
                .BindToLocalScale(_splash);
        }
    }
}