using System;
using System.Collections.Generic;
using Interface;
using UnityEngine;
using UnityEngine.UI;

namespace Popups
{
    public abstract class Popup : MonoBehaviour
    {
        private readonly List<IImageBlock> _subscriptions = new ();

        [SerializeField] private Button _exitButton;
        
        private GameObject _gameObject;
        
        private void Start()
        {
            _gameObject = gameObject;
            _exitButton.onClick.AddListener(Exit);
            Exit();
        }

        private void OnDestroy()
        {
            _exitButton.onClick.RemoveListener(Exit);
            
            for (int i = 0; i < _subscriptions.Count; i++)
            {
                _subscriptions[i].Clicked -= OnImageBlockClicked;
            }
        }

        public void Add(IImageBlock imageBlock)
        {
            if (_subscriptions.Contains(imageBlock))
            {
                throw new ArgumentException("Already subscribed");
            }

            imageBlock.Clicked += OnImageBlockClicked;
            _subscriptions.Add(imageBlock);
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