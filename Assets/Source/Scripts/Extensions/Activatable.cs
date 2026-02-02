using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Extensions
{
    public class Activatable : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Image _enabledImage;
        [SerializeField] private Color _enabledTextColor;

        private Color _defaultTextColor;

        public void Initialize()
        {
            _defaultTextColor = _text.color;
        }

        public void SetActive(bool isActive)
        {
            _text.color = isActive ? _enabledTextColor : _defaultTextColor;
            _enabledImage.enabled = isActive;
        }
    }
}