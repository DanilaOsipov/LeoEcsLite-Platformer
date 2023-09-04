using System;
using UnityEngine;
using UnityEngine.UI;

namespace Contexts.UI.View.Implemented
{
    public class UILevelCompletedPanelView : UIPanelView
    {
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _restartButton;

        public event Action OnExitButtonClick = delegate { };
        public event Action OnRestartButtonClick = delegate { };

        private void Awake()
        {
            _exitButton.onClick.AddListener(OnExitButtonClickHandler);
            _restartButton.onClick.AddListener(OnRestartButtonClickHandler);
        }

        private void OnRestartButtonClickHandler() => OnRestartButtonClick();

        private void OnExitButtonClickHandler() => OnExitButtonClick();
    }
}