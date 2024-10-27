using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code
{
    public class ClickerObjectView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        
        public event Action OnClick;
        
        private void Awake()
        {
            _button.onClick.AddListener(OnClickHandler);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OnClickHandler);
        }

        public void SetInteractable(bool value) =>
            _button.interactable = value;

        private void OnClickHandler() => 
            OnClick?.Invoke();
    }
}