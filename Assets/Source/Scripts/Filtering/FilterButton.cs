using System;
using Extensions;
using Filtering.Filter;
using UnityEngine;
using UnityEngine.UI;

namespace Filtering
{
    [RequireComponent(typeof(Activatable))]
    public class FilterButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        
        [field: SerializeField] public BlockFilter BlockFilter { get; private set; }
        
        public event Action<FilterButton> Clicked;

        private void Start()
        {
            _button.onClick.AddListener(OnButtonClicked);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            Clicked?.Invoke(this);
        }
    }
}