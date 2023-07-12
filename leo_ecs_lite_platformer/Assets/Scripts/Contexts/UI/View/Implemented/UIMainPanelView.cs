using System;
using UnityEngine;
using UnityEngine.UI;

namespace Contexts.UI.View.Implemented
{
    public class UIMainPanelView : UIPanelView
    {
        [SerializeField] private Button _startButton;

        public event Action OnStartButtonClick = delegate { };

        private void Awake() => _startButton.onClick.AddListener(OnStartButtonClickHandler);

        private void OnStartButtonClickHandler() => OnStartButtonClick();
    }
}