using System;
using Code.Extensions;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Pool;

namespace Code.Services.FloatingText
{
    public class FloatingTextService : MonoBehaviour, IFloatingTextService
    {
        [SerializeField] private Transform _root;
        [SerializeField] private FloatingTextView _textPrefab;
        
        private const float FloatDuration = 0.5f;
        private const int TextInitialAmount = 5;
        private ObjectPool<FloatingTextView> _objectPool;

        private void Awake()
        {
            _objectPool = new ObjectPool<FloatingTextView>(
                createFunc: CreateFloatingTextView, 
                actionOnGet: PrepareFloatingTextView,
                actionOnRelease: ResetFloatingTextView,
                actionOnDestroy: DestroyFloatingTextView);
            
            _objectPool.WarmUp(TextInitialAmount);
        }

        public void SetupText(string text, Vector3 startPosition, Vector3 endPosition, Action onPositionReached)
        {
            FloatingTextView floatingTextView = _objectPool.Get();
            floatingTextView.SetText(text);
            floatingTextView.transform.position = startPosition;
            floatingTextView.transform.DOMove(endPosition, FloatDuration).SetEase(Ease.OutQuart).OnComplete(() =>
            {
                onPositionReached?.Invoke();
                _objectPool.Release(floatingTextView);
            });
        }

        private FloatingTextView CreateFloatingTextView()
        {
            FloatingTextView floatingTextView = Instantiate(_textPrefab, _root);
            return floatingTextView;
        }

        private void PrepareFloatingTextView(FloatingTextView textView) => 
            textView.gameObject.SetActive(true);

        private void ResetFloatingTextView(FloatingTextView textView) => 
            textView.gameObject.SetActive(false);

        private void DestroyFloatingTextView(FloatingTextView textView) => 
            Destroy(textView.gameObject);
    }
}