using System;
using System.Collections.Generic;
using Interface;
using LevelPanel;
using UnityEngine;
using UnityEngine.UI;

namespace Popups
{
    public abstract class Popup : MonoBehaviour
    {
        private readonly List<BlockClickReader> _subscriptions = new ();

        [SerializeField] private Button _exitButton;
        
        private GameObject _gameObject;

        private void OnDestroy()
        {
            _exitButton.onClick.RemoveListener(Exit);
            
            for (int i = 0; i < _subscriptions.Count; i++)
            {
                _subscriptions[i].Clicked -= OnImageBlockClicked;
            }
        }

        public void Initialize()
        {
            _gameObject = gameObject;
            _exitButton.onClick.AddListener(Exit);
            Exit();
        }
        
        public void Add(BlockClickReader clickReader)
        {
            if (_subscriptions.Contains(clickReader))
            {
                throw new ArgumentException("Already subscribed");
            }

            clickReader.Clicked += OnImageBlockClicked;
            _subscriptions.Add(clickReader);
        }

        protected virtual void OnImageBlockClicked(IImageBlock imageBlock)
        {
            _gameObject.SetActive(true);
        }

        private void Exit()
        {
            _gameObject.SetActive(false);
        }
    }
}