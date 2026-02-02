using System;
using System.Collections.Generic;
using System.Linq;
using Extensions;
using LevelPanel;
using UnityEngine;
using UnityEngine.UI;

namespace Filtering
{
    public sealed class FilterPanel : MonoBehaviour
    {
        private const float SliderMaxValue = 1;
        
        private readonly Dictionary<FilterButton, Activatable> _filters = new ();

        [SerializeField] private FilterButton[] _filterButtons;
        [SerializeField] private FilterButton _firstFilter;
        [SerializeField] private ScrollRect _scrollRect;
        
        private LevelBlock[] _blocks;
        private Activatable _lastActiveButton;
        
        private void Start()
        {
            foreach (FilterButton filterButton in _filters.Keys)
            {
                filterButton.Clicked += Filter;
            }
        }

        private void OnDestroy()
        {
            foreach (FilterButton filterButton in _filters.Keys)
            {
                filterButton.Clicked -= Filter;
            }
        }

        public void Initialize(IEnumerable<LevelBlock> blocks)
        {
            _blocks = blocks.ToArray();

            foreach (FilterButton filterButton in _filterButtons)
            {
                Activatable activatable = filterButton.GetComponent<Activatable>();
                
                _filters.Add(filterButton, activatable);
            }
            
            Filter(_firstFilter);
        }

        private void Filter(FilterButton filterButton)
        {
            if (_filters.TryGetValue(filterButton, out Activatable activatable) == false)
            {
                throw new ArgumentException(nameof(filterButton));
            }
            
            filterButton.BlockFilter.Sort(_blocks);
            _lastActiveButton?.SetActive(false);
            
            _lastActiveButton = activatable;
            
            _lastActiveButton.SetActive(true);
            _scrollRect.normalizedPosition = new Vector2(0, SliderMaxValue);
        }
    }
}